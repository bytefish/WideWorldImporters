// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using WpfDataGridFilter.DynamicLinq.Infrastructure;
using WpfDataGridFilter.Infrastructure;
using WpfDataGridFilter.Models;
using WpfDataGridFilter.Translations;

namespace WideWorldImporters.Desktop.Client.Controls
{
    public static class GeographyFilter
    {
        // Filter Type
        public static FilterType GeoDistanceFilterType = new FilterType { Name = "GeoDistanceFilter" };

        // Filter Operators
        public static class FilterOperators
        {
            public static FilterOperator DistanceLessThan = new FilterOperator { Name = nameof(DistanceLessThan) };
            public static FilterOperator DistanceLessEqualThan = new FilterOperator { Name = nameof(DistanceLessEqualThan) };
            public static FilterOperator DistanceGreaterThan = new FilterOperator { Name = nameof(DistanceGreaterThan) };
            public static FilterOperator DistanceGreaterEqualThan = new FilterOperator { Name = nameof(DistanceGreaterEqualThan) };
        }

        // Translations
        public static class Translations
        {
            public static List<Translation<FilterOperator>> FilterOperatorTranslations =
            [
                new Translation<FilterOperator>() { Value = FilterOperators.DistanceLessThan, Text = "Distance Less Than"},
                new Translation<FilterOperator>() { Value = FilterOperators.DistanceLessEqualThan, Text = "Distance Less Equal Than"},
                new Translation<FilterOperator>() { Value = FilterOperators.DistanceGreaterThan, Text = "Distance Greater Than"},
                new Translation<FilterOperator>() { Value = FilterOperators.DistanceGreaterEqualThan, Text = "Distance Greater Equal Than"},
            ];
        }
    }
}