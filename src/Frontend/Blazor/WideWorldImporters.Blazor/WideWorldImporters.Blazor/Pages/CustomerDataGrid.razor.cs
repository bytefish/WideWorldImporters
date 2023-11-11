// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using WideWorldImporters.Blazor.Components;
using WideWorldImporters.Blazor.Infrastructure;
using WideWorldImporters.Blazor.Shared.Extensions;
using WideWorldImporters.Blazor.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.OData.Client;
using WideWorldImportersService;

namespace WideWorldImporters.Blazor.Pages
{
    public partial class CustomerDataGrid
    {
        /// <summary>
        /// The <see cref="DataServiceContext"/> to access the OData Service.
        /// </summary>
        [Inject]
        public required Container Container { get; set; }

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

        public CustomerDataGrid()
        {
            CurrentFiltersChanged = new(EventCallback.Factory.Create<FilterState>(this, RefreshData));
        }

        protected override Task OnInitializedAsync()
        {
            CustomerProvider = async request =>
            {
                var response = await GetCustomers(request);

                return GridItemsProviderResult.From(items: response.ToList(), totalItemCount: (int)response.Count);
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

        private async Task<QueryOperationResponse<Customer>> GetCustomers(GridItemsProviderRequest<Customer> request)
        {
            var sorts = DataGridUtils.GetSortColumns(request);
            var filters = FilterState.Filters.Values.ToList();

            var dataServiceQuery = GetDataServiceQuery(sorts, filters, Pagination.CurrentPageIndex, Pagination.ItemsPerPage);

            var result = await dataServiceQuery.ExecuteAsync(request.CancellationToken);

            return (QueryOperationResponse<Customer>)result;
        }

        private DataServiceQuery<Customer> GetDataServiceQuery(List<SortColumn> sortColumns, List<FilterDescriptor> filters,  int pageNumber, int pageSize)
        {
            var query = Container.Customers.Expand(x => x.LastEditedByNavigation)
                .Page(pageNumber + 1, pageSize)
                .Filter(filters)
                .SortBy(sortColumns)
                .IncludeCount(true);

            return (DataServiceQuery<Customer>)query;
        }
    }
}
