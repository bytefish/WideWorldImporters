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
        /// Gets or sets the expand clause.
        /// </summary>
        public string[]? Expand { get; set; }

        /// <summary>
        /// Gets or sets the order by clause.
        /// </summary>
        public string[]? OrderBy { get; set; }

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
        private string? _filter;
        private List<string> _orderby = new();
        private List<string> _expand = new();

        /// <summary>
        /// Sets the $top and $skip clauses using the page information.
        /// </summary>
        /// <param name="pageNumber">Page number to request</param>
        /// <param name="pageNumber">Page size to request</param>
        /// <returns>The <see cref="ODataQueryParametersBuilder"/> with the $top and $skip clauses set</returns>
        public ODataQueryParametersBuilder SetPage(int pageNumber, int pageSize)
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
        public ODataQueryParametersBuilder SetFilter(List<FilterDescriptor> filterDescriptors)
        {
            _filter = ODataUtils.Translate(filterDescriptors);

            return this;
        }

        /// <summary>
        /// Sets the $expand clause.
        /// </summary>
        /// <param name="filterDescriptors">Filter Descriptors to filter for</param>
        /// <returns>The <see cref="ODataQueryParametersBuilder"/> with the $filter clause set</returns>
        public ODataQueryParametersBuilder AddExpand(string expand)
        {
            if (!_expand.Contains(expand))
            {
                _expand.Add(expand);
            }

            return this;
        }

        /// <summary>
        /// Sets the $orderby clause.
        /// </summary>
        /// <param name="columns">List of Columns to sort by</param>
        /// <returns>The <see cref="ODataQueryParametersBuilder"/> with the $orderby clause set</returns>
        public ODataQueryParametersBuilder AddOrderBy(SortColumn column)
        {
            var orderByClause = GetOrderByColumns(new[] { column });

            if (string.IsNullOrWhiteSpace(orderByClause))
            {
                _orderby.Add(orderByClause);
            }

            return this;
        }

        /// <summary>
        /// Sets the $orderby clause.
        /// </summary>
        /// <param name="columns">List of Columns to sort by</param>
        /// <returns>The <see cref="ODataQueryParametersBuilder"/> with the $orderby clause set</returns>
        public ODataQueryParametersBuilder AddOrderBy(List<SortColumn> columns)
        {
            if (columns.Count == 0)
            {
                return this;
            }

            var orderbyClause = GetOrderByColumns(columns);

            if (string.IsNullOrWhiteSpace(orderbyClause))
            {
                return this;
            }

            _orderby.Add(orderbyClause);

            return this;
        }

        /// <summary>
        /// Translates the given <paramref name="columns"/> to OData string.
        /// </summary>
        /// <param name="columns">Columns to convert into the OData $orderby string</param>
        /// <returns>The $orderby clause from the given columns</returns>
        private string GetOrderByColumns(ICollection<SortColumn> columns)
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
                Filter = _filter,
                Expand = _expand.Any() ? _expand.ToArray() : null,
                OrderBy = _orderby.Any() ? _orderby.ToArray() : null,
            };
        }
    }
}
