// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService;
using WideWorldImporters.Shared.ApiSdk;
using WideWorldImporters.Client.Blazor.Shared.OData;
using WideWorldImporters.Client.Blazor.Infrastructure;
using WideWorldImporters.Client.Blazor.Components;
using WideWorldImporters.Client.Blazor.Extensions;

namespace WideWorldImporters.Client.Blazor.Pages
{
    public partial class CustomersDataGrid
    {
        /// <summary>
        /// Provides the Data Items.
        /// </summary>
        private GridItemsProvider<Customer> CustomerProvider = default!;

        /// <summary>
        /// DataGrid.
        /// </summary>
        private FluentDataGrid<Customer> DataGrid = default!;

        /// <summary>
        /// The current Pagination State.
        /// </summary>
        private readonly PaginationState Pagination = new() { ItemsPerPage = 10 };

        /// <summary>
        /// The current Filter State.
        /// </summary>
        private readonly FilterState FilterState = new();

        /// <summary>
        /// Reacts on Paginator Changes.
        /// </summary>
        private readonly EventCallbackSubscriber<FilterState> CurrentFiltersChanged;

        public CustomersDataGrid()
        {
            CurrentFiltersChanged = new(EventCallback.Factory.Create<FilterState>(this, RefreshData));
        }

        protected override Task OnInitializedAsync()
        {
            CustomerProvider = async request =>
            {
                var response = await GetCustomers(request);

                if (response == null)
                {
                    return GridItemsProviderResult.From(items: new List<Customer>(), totalItemCount: 0);
                }

                var entities = response.Value;

                if (entities == null)
                {
                    return GridItemsProviderResult.From(items: new List<Customer>(), totalItemCount: 0);
                }

                int count = response.GetODataCount();

                return GridItemsProviderResult.From(items: entities, totalItemCount: count);
            };

            return base.OnInitializedAsync();
        }



        /// <inheritdoc />
        protected override Task OnParametersSetAsync()
        {
            // The associated filter state may have been added/removed/replaced
            CurrentFiltersChanged.SubscribeOrMove(FilterState.CurrentFiltersChanged);

            return Task.CompletedTask;
        }

        private Task RefreshData()
        {
            return DataGrid.RefreshDataAsync();
        }

        private async Task<CustomerCollectionResponse?> GetCustomers(GridItemsProviderRequest<Customer> request)
        {
            // Extract all Sort Columns from the Blazor FluentUI DataGrid
            var sortColumns = DataGridUtils.GetSortColumns(request);

            // Extract all Filters from the Blazor FluentUI DataGrid
            var filters = FilterState.Filters.Values.ToList();

            // Build the ODataQueryParameters using the ODataQueryParametersBuilder
            var parameters = ODataQueryParameters.Builder
                .Page(Pagination.CurrentPageIndex + 1, Pagination.ItemsPerPage)
                .AddExpand(nameof(Customer.LastEditedByNavigation))
                .Filter(filters)
                .OrderBy(sortColumns)
                .Build();

            // Get the Data using the ApiClient from the SDK
            return await ApiClient.Odata.Customers.GetAsync(request =>
            {
                request.QueryParameters.Count = true;
                
                request.QueryParameters.Top = parameters.Top;
                request.QueryParameters.Skip = parameters.Skip;

                if(parameters.Expand != null)
                {
                    request.QueryParameters.Expand = parameters.Expand;
                }

                if (!string.IsNullOrWhiteSpace(parameters.Filter))
                {
                    request.QueryParameters.Filter = parameters.Filter;
                }

                if (!string.IsNullOrWhiteSpace(parameters.OrderBy))
                {
                    request.QueryParameters.Orderby = new[] { parameters.OrderBy };
                }
            });
        }
    }
}
