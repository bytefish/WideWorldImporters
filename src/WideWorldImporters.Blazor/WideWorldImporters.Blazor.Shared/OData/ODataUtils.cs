// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Globalization;
using WideWorldImporters.Blazor.Shared.Models;

namespace WideWorldImporters.Blazor.Shared.OData
{
    public static class ODataUtils
    {
        public static string Translate(List<FilterDescriptor> filterDescriptors)
        {
            if (filterDescriptors.Count == 0)
            {
                return string.Empty;
            }

            List<string> filters = new();

            foreach (FilterDescriptor filterDescriptor in filterDescriptors)
            {
                if (filterDescriptor.FilterOperator == FilterOperatorEnum.None)
                {
                    continue;
                }

                var filter = TranslateFilter(filterDescriptor);

                filters.Add(filter);
            }

            return string.Join(" and ", filters
                .Select(filter => $"({filter})"));
        }

        private static string TranslateFilter(FilterDescriptor filterDescriptor)
        {
            switch (filterDescriptor.FilterType)
            {
                case FilterTypeEnum.BooleanFilter:
                    return TranslateBooleanFilter((BooleanFilterDescriptor)filterDescriptor);
                case FilterTypeEnum.DateFilter:
                    return TranslateDateFilter((DateFilterDescriptor)filterDescriptor);
                case FilterTypeEnum.DateTimeFilter:
                    return TranslateDateTimeFilter((DateTimeFilterDescriptor)filterDescriptor);
                case FilterTypeEnum.StringFilter:
                    return TranslateStringFilter((StringFilterDescriptor)filterDescriptor);
                case FilterTypeEnum.NumericFilter:
                    return TranslateNumericFilter((NumericFilterDescriptor)filterDescriptor);
                default:
                    throw new ArgumentException($"Could not translate Filter Type '{filterDescriptor.FilterType}'");

            }
        }

        private static string TranslateBooleanFilter(BooleanFilterDescriptor filterDescriptor)
        {
            switch (filterDescriptor.FilterOperator)
            {
                case FilterOperatorEnum.IsNull:
                    return $"{filterDescriptor.PropertyName} eq null";
                case FilterOperatorEnum.IsNotNull:
                    return $"{filterDescriptor.PropertyName} ne null";
                case FilterOperatorEnum.All:
                    return $"{filterDescriptor.PropertyName} ne null";
                case FilterOperatorEnum.Yes:
                    return $"{filterDescriptor.PropertyName} eq true";
                case FilterOperatorEnum.No:
                    return $"{filterDescriptor.PropertyName} eq false";
                default:
                    throw new ArgumentException($"Could not translate Filter Operator '{filterDescriptor.FilterOperator}'");
            }
        }

        private static string TranslateDateFilter(DateFilterDescriptor filterDescriptor)
        {
            var startDate = ToODataDate(filterDescriptor.StartDate);
            var endDate = ToODataDate(filterDescriptor.EndDate);

            switch (filterDescriptor.FilterOperator)
            {
                case FilterOperatorEnum.IsNull:
                    return $"{filterDescriptor.PropertyName} eq null";
                case FilterOperatorEnum.IsNotNull:
                    return $"{filterDescriptor.PropertyName} ne null";
                case FilterOperatorEnum.IsEqualTo:
                    return $"date({filterDescriptor.PropertyName}) eq {startDate}";
                case FilterOperatorEnum.IsNotEqualTo:
                    return $"date({filterDescriptor.PropertyName}) ne {startDate}";
                case FilterOperatorEnum.After:
                case FilterOperatorEnum.IsGreaterThan:
                    return $"date({filterDescriptor.PropertyName}) gt {startDate}";
                case FilterOperatorEnum.IsGreaterThanOrEqualTo:
                    return $"date({filterDescriptor.PropertyName}) ge {startDate}";
                case FilterOperatorEnum.Before:
                case FilterOperatorEnum.IsLessThan:
                    return $"date({filterDescriptor.PropertyName}) lt {startDate}";
                case FilterOperatorEnum.IsLessThanOrEqualTo:
                    return $"date({filterDescriptor.PropertyName}) le {startDate}";
                case FilterOperatorEnum.BetweenExclusive:
                    return $"(date({filterDescriptor.PropertyName}) gt {startDate}) and (date({filterDescriptor.PropertyName}) lt {endDate})";
                case FilterOperatorEnum.BetweenInclusive:
                    return $"(date({filterDescriptor.PropertyName}) ge {startDate}) and (date({filterDescriptor.PropertyName}) le {endDate})";
                default:
                    throw new ArgumentException($"Could not translate Filter Operator '{filterDescriptor.FilterOperator}'");
            }
        }

        private static string TranslateDateTimeFilter(DateTimeFilterDescriptor filterDescriptor)
        {
            var startDate = ToODataDateTime(filterDescriptor.StartDateTime);
            var endDate = ToODataDateTime(filterDescriptor.EndDateTime);

            switch (filterDescriptor.FilterOperator)
            {
                case FilterOperatorEnum.IsNull:
                    return $"{filterDescriptor.PropertyName} eq null";
                case FilterOperatorEnum.IsNotNull:
                    return $"{filterDescriptor.PropertyName} ne null";
                case FilterOperatorEnum.IsEqualTo:
                    return $"{filterDescriptor.PropertyName} eq {startDate}";
                case FilterOperatorEnum.IsNotEqualTo:
                    return $"{filterDescriptor.PropertyName} ne {startDate}";
                case FilterOperatorEnum.After:
                case FilterOperatorEnum.IsGreaterThan:
                    return $"{filterDescriptor.PropertyName} gt {startDate}";
                case FilterOperatorEnum.IsGreaterThanOrEqualTo:
                    return $"{filterDescriptor.PropertyName} ge {startDate}";
                case FilterOperatorEnum.Before:
                case FilterOperatorEnum.IsLessThan:
                    return $"{filterDescriptor.PropertyName} lt {startDate}";
                case FilterOperatorEnum.IsLessThanOrEqualTo:
                    return $"{filterDescriptor.PropertyName} le {startDate}";
                case FilterOperatorEnum.BetweenExclusive:
                    return $"({filterDescriptor.PropertyName} gt {startDate}) and ({filterDescriptor.PropertyName} lt {endDate})";
                case FilterOperatorEnum.BetweenInclusive:
                    return $"({filterDescriptor.PropertyName} ge {startDate}) and ({filterDescriptor.PropertyName} le {endDate})";
                default:
                    throw new ArgumentException($"Could not translate Filter Operator '{filterDescriptor.FilterOperator}'");
            }
        }

        private static string TranslateStringFilter(StringFilterDescriptor filterDescriptor)
        {
            switch (filterDescriptor.FilterOperator)
            {
                case FilterOperatorEnum.IsNull:
                    return $"{filterDescriptor.PropertyName} eq null";
                case FilterOperatorEnum.IsNotNull:
                    return $"{filterDescriptor.PropertyName} ne null";
                case FilterOperatorEnum.IsEqualTo:
                    return $"{filterDescriptor.PropertyName} eq '{filterDescriptor.Value}'";
                case FilterOperatorEnum.IsNotEqualTo:
                    return $"{filterDescriptor.PropertyName} ne '{filterDescriptor.Value}'";
                case FilterOperatorEnum.IsEmpty:
                    return $"({filterDescriptor.PropertyName} eq null) or ({filterDescriptor.PropertyName} eq '')";
                case FilterOperatorEnum.IsNotEmpty:
                    return $"({filterDescriptor.PropertyName} ne null) and ({filterDescriptor.PropertyName} ne '')";
                case FilterOperatorEnum.Contains:
                    return $"contains({filterDescriptor.PropertyName}, '{filterDescriptor.Value}')";
                case FilterOperatorEnum.NotContains:
                    return $"indexof({filterDescriptor.PropertyName}, '{filterDescriptor.Value}') eq - 1";
                case FilterOperatorEnum.StartsWith:
                    return $"startswith({filterDescriptor.PropertyName}, '{filterDescriptor.Value}')";
                case FilterOperatorEnum.EndsWith:
                    return $"endswith({filterDescriptor.PropertyName}, '{filterDescriptor.Value}')";
                default:
                    throw new ArgumentException($"Could not translate Filter Operator '{filterDescriptor.FilterOperator}'");
            }
        }

        private static string TranslateNumericFilter(NumericFilterDescriptor filterDescriptor)
        {
            var low = filterDescriptor.LowerValue?.ToString(CultureInfo.InvariantCulture);
            var high = filterDescriptor.UpperValue?.ToString(CultureInfo.InvariantCulture);

            switch (filterDescriptor.FilterOperator)
            {
                case FilterOperatorEnum.IsNull:
                    return $"{filterDescriptor.PropertyName} eq null";
                case FilterOperatorEnum.IsNotNull:
                    return $"{filterDescriptor.PropertyName} ne null";
                case FilterOperatorEnum.IsEqualTo:
                    return $"{filterDescriptor.PropertyName} eq {low}";
                case FilterOperatorEnum.IsNotEqualTo:
                    return $"{filterDescriptor.PropertyName} ne {low}";
                case FilterOperatorEnum.IsGreaterThan:
                    return $"{filterDescriptor.PropertyName} gt {low}";
                case FilterOperatorEnum.IsGreaterThanOrEqualTo:
                    return $"{filterDescriptor.PropertyName} ge {low}";
                case FilterOperatorEnum.IsLessThan:
                    return $"{filterDescriptor.PropertyName} lt {low}";
                case FilterOperatorEnum.IsLessThanOrEqualTo:
                    return $"{filterDescriptor.PropertyName} le {low}";
                case FilterOperatorEnum.BetweenExclusive:
                    return $"({filterDescriptor.PropertyName} gt {low}) and({filterDescriptor.PropertyName} lt {high})";
                case FilterOperatorEnum.BetweenInclusive:
                    return $"({filterDescriptor.PropertyName} ge {low}) and({filterDescriptor.PropertyName} le {high})";
                default:
                    throw new ArgumentException($"Could not translate Filter Operator '{filterDescriptor.FilterOperator}'");
            }
        }

        private static string? ToODataDate(DateTimeOffset? dateTimeOffset)
        {
            if (dateTimeOffset == null)
            {
                return null;
            }

            return dateTimeOffset.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        private static string? ToODataDateTime(DateTimeOffset? dateTimeOffset)
        {
            if (dateTimeOffset == null)
            {
                return null;
            }

            return dateTimeOffset.Value
                // ... Convert to Utc Zone
                .ToUniversalTime()
                // ... in ISO 8601 Format
                .ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
        }
    }
}