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
    public partial class ColdRoomTemperaturesDataGrid
    {
        /// <summary>
        /// Provides the Data Items.
        /// </summary>
        private GridItemsProvider<ColdRoomTemperature> ColdRoomTemperatureProvider = default!;

        /// <summary>
        /// DataGrid.
        /// </summary>
        private FluentDataGrid<ColdRoomTemperature> DataGrid = default!;

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

        public ColdRoomTemperaturesDataGrid()
        {
            CurrentFiltersChanged = new(EventCallback.Factory.Create<FilterState>(this, RefreshData));
        }

        protected override Task OnInitializedAsync()
        {
            ColdRoomTemperatureProvider = async request =>
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

        private async Task<QueryOperationResponse<ColdRoomTemperature>> GetCustomers(GridItemsProviderRequest<ColdRoomTemperature> request)
        {
            var sorts = DataGridUtils.GetSortColumns(request);
            var filters = FilterState.Filters.Values.ToList();

            var dataServiceQuery = GetDataServiceQuery(sorts, filters, Pagination.CurrentPageIndex, Pagination.ItemsPerPage);

            var result = await dataServiceQuery.ExecuteAsync(request.CancellationToken);

            return (QueryOperationResponse<ColdRoomTemperature>)result;
        }

        private DataServiceQuery<ColdRoomTemperature> GetDataServiceQuery(List<SortColumn> sortColumns, List<FilterDescriptor> filters,  int pageNumber, int pageSize)
        {
            var query = Container.ColdRoomTemperatures
                .Page(pageNumber + 1, pageSize)
                .Filter(filters)
                .SortBy(sortColumns)
                .IncludeCount(true);

            return (DataServiceQuery<ColdRoomTemperature>)query;
        }
    }
}
