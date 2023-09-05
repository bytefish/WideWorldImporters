// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using WideWorldImporters.Blazor.Shared.Models;
using Microsoft.OData.Client;

namespace WideWorldImporters.Blazor.Shared.Extensions
{
    /// <summary>
    /// OData Extensions to simplify working with a Grid in a WinUI 3 application.
    /// </summary>
    public static class ODataExtensions
    {
        /// <summary>
        /// Adds the $top and $skip clauses to the <see cref="DataServiceQuery"/> to add pagination.
        /// </summary>
        /// <remarks>
        /// The <paramref name="pageNumber"/> starts with 1.
        /// </remarks>
        /// <typeparam name="TElement">Entity to query for</typeparam>
        /// <param name="dataServiceQuery">The <see cref="DataServiceQuery"/> to modify</param>
        /// <param name="pageNumber">Page Number (starting with 1)</param>
        /// <param name="pageSize">Page size</param>
        /// <returns><see cref="DataServiceQuery"/> with Pagination</returns>
        public static DataServiceQuery<TElement> Page<TElement>(this DataServiceQuery<TElement> dataServiceQuery, int pageNumber, int pageSize)
        {
            var skip = (pageNumber - 1) * pageSize;
            var top = pageSize;

            var query = dataServiceQuery
                .Skip(skip)
                .Take(top);

            return (DataServiceQuery<TElement>) query;
        }

        /// <summary>
        /// Adds a $filter clause to a <see cref="DataServiceQuery"/>.
        /// </summary>
        /// <typeparam name="TElement">Entity to Filter</typeparam>
        /// <param name="dataServiceQuery">DataServiceQuery to add the $filter clause to</param>
        /// <param name="filters">Filters to apply</param>
        /// <returns><see cref="DataServiceQuery"/> with filtering</returns>
        public static DataServiceQuery<TElement> Filter<TElement>(this DataServiceQuery<TElement> dataServiceQuery, List<FilterDescriptor> filters)
        {
            if(filters.Count == 0)
            {
                return dataServiceQuery;
            }

            var filter = ODataUtils.Translate(filters);

            if (!string.IsNullOrWhiteSpace(filter))
            {
                dataServiceQuery = dataServiceQuery.AddQueryOption("$filter", filter);
            }

            return dataServiceQuery;
        }

        /// <summary>
        /// Adds the $orderby clause to a <see cref="DataServiceQuery"/>.
        /// </summary>
        /// <typeparam name="TElement">Entity to Query for</typeparam>
        /// <param name="dataServiceQuery">DataServiceQuery to add the $orderby clause to</param>
        /// <param name="columns">Columns to sort</param>
        /// <returns><see cref="DataServiceQuery"/> with sorting</returns>
        public static DataServiceQuery<TElement> SortBy<TElement>(this DataServiceQuery<TElement> dataServiceQuery, List<SortColumn> columns)
        {
            var sortColumns = GetOrderByColumns(columns);

            if (!string.IsNullOrWhiteSpace(sortColumns))
            {
                dataServiceQuery = dataServiceQuery.AddQueryOption("$orderby", sortColumns);
            }

            return dataServiceQuery;
        }

        /// <summary>
        /// Sorts the DataGrid by the specified column, updating the column header to reflect the current sort direction.
        /// </summary>
        /// <param name="columns">The Columns to sort.</param>
        public static string GetOrderByColumns(List<SortColumn> columns)
        {
            var sortColumns = columns
                // We need a Tag with the OData Path:
                .Where(column => column.PropertyName != null)
                // Turn into OData string:
                .Select(column =>
                {
                    var sortDirection = column.SortDirection == SortDirectionEnum.Descending ? "desc" : "asc";

                    return $"{column.PropertyName} {sortDirection}";
                });

            return string.Join(",", sortColumns);
        }
    }
}
