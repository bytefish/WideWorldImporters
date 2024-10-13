// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WideWorldImporters.Shared.Infrastructure
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
}
