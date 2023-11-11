// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using WideWorldImporters.Client.Blazor.Shared.Models;

namespace WideWorldImporters.Client.Blazor.Shared.OData
{
    /// <summary>
    /// Holds the values for the OData $skip, $top, $filter and $orderby clauses.
    /// </summary>
    public class ODataQueryParameters
    {
        /// <summary>
        /// Gets or sets the number of elements to skip.
        /// </summary>
        public int? Skip { get; set; }

        /// <summary>
        /// Gets or sets the number of elements to take.
        /// </summary>
        public int? Top { get; set; }

        /// <summary>
        /// Gets or sets the filter clause.
        /// </summary>
        public string? Filter { get; set; }

        /// <summary>
        /// Gets or sets the order by clause.
        /// </summary>
        public string? OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the option to include the count (default: <see cref="true"/>).
        /// </summary>
        public bool IncludeCount { get; set; } = true;

        /// <summary>
        /// Gets an <see cref="ODataQueryParametersBuilder"/> to create <see cref="ODataQueryParameters"/>.
        /// </summary>
        public static ODataQueryParametersBuilder Builder => new ODataQueryParametersBuilder();
    }

    /// <summary>
    /// A Builder to simplify building <see cref="ODataQueryParameters"/>.
    /// </summary>
    public class ODataQueryParametersBuilder
    {
        private int? _skip;
        private int? _top;
        private string? _orderby;
        private string? _filter;

        /// <summary>
        /// Sets the $top and $skip clauses using the page information.
        /// </summary>
        /// <param name="pageNumber">Page number to request</param>
        /// <param name="pageNumber">Page size to request</param>
        /// <returns>The <see cref="ODataQueryParametersBuilder"/> with the $top and $skip clauses set</returns>
        public ODataQueryParametersBuilder Page(int pageNumber, int pageSize)
        {
            _skip = (pageNumber - 1) * pageSize;
            _top = pageSize;

            return this;
        }

        /// <summary>
        /// Sets the $filter clause.
        /// </summary>
        /// <param name="filterDescriptors">Filter Descriptors to filter for</param>
        /// <returns>The <see cref="ODataQueryParametersBuilder"/> with the $filter clause set</returns>
        public ODataQueryParametersBuilder Filter(List<FilterDescriptor> filterDescriptors)
        {
            _filter = ODataUtils.Translate(filterDescriptors);

            return this;
        }

        /// <summary>
        /// Sets the $orderby clause.
        /// </summary>
        /// <param name="columns">List of Columns to sort by</param>
        /// <returns>The <see cref="ODataQueryParametersBuilder"/> with the $orderby clause set</returns>
        public ODataQueryParametersBuilder OrderBy(List<SortColumn> columns)
        {
            _orderby = GetOrderByColumns(columns);

            return this;
        }

        /// <summary>
        /// Translates the given <paramref name="columns"/> to OData string.
        /// </summary>
        /// <param name="columns">Columns to convert into the OData $orderby string</param>
        /// <returns>The $orderby clause from the given columns</returns>
        private string GetOrderByColumns(List<SortColumn> columns)
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

        /// <summary>
        /// Builds the <see cref="ODataQueryParameters"/> object with the clauses set.
        /// </summary>
        /// <returns><see cref="ODataQueryParameters"/> with the OData clauses applied</returns>
        public ODataQueryParameters Build()
        {
            return new ODataQueryParameters
            {
                Skip = _skip,
                Top = _top,
                OrderBy = _orderby,
                Filter = _filter,
            };
        }
    }
}
