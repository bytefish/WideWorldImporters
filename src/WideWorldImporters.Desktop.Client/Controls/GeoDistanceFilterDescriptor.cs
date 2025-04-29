// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using WpfDataGridFilter.Models;

namespace WideWorldImporters.Desktop.Client.Controls
{
    /// <summary>
    /// The FilterDescriptor for Geography Distances.
    /// </summary>
    public record GeoDistanceFilterDescriptor : FilterDescriptor
    {
        public override FilterType FilterType => GeographyFilter.GeoDistanceFilterType;

        /// <summary>
        /// Gets or sets the Latitude.
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// Gets or sets the Longitude.
        /// </summary>
        public double? Longitude { get; set; }

        /// <summary>
        /// Gets or sets the Distance.
        /// </summary>
        public double? Distance { get; set; }
    }
}
