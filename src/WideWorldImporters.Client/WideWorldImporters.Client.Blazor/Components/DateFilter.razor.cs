// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using WideWorldImporters.Client.Blazor.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace WideWorldImporters.Client.Blazor.Components
{
    public partial class DateFilter
    {
        /// <summary>
        /// The Property Name.
        /// </summary>
        [Parameter]
        public required string PropertyName { get; set; }

        /// <summary>
        /// The current FilterState.
        /// </summary>
        [Parameter]
        public required FilterState FilterState { get; set; }
        /// <summary>
        /// Filter Options available for the DateTimeFilter.
        /// </summary>
        private readonly FilterOperatorEnum[] filterOperatorOptions = new[]
        {
            FilterOperatorEnum.IsNull,
            FilterOperatorEnum.IsNotNull,
            FilterOperatorEnum.IsEqualTo,
            FilterOperatorEnum.IsNotEqualTo,
            FilterOperatorEnum.After,
            FilterOperatorEnum.IsGreaterThan,
            FilterOperatorEnum.IsGreaterThanOrEqualTo,
            FilterOperatorEnum.Before,
            FilterOperatorEnum.IsLessThan,
            FilterOperatorEnum.IsLessThanOrEqualTo,
            FilterOperatorEnum.BetweenExclusive,
            FilterOperatorEnum.BetweenInclusive
        };

        protected FilterOperatorEnum _filterOperator { get; set; }

        protected DateTime? _startDateTime { get; set; }

        protected DateTime? _endDateTime { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            SetFilterValues();
        }

        private bool IsStartDateTimeDisabled()
        {
            return _filterOperator == FilterOperatorEnum.None
                || _filterOperator == FilterOperatorEnum.IsNull
                || _filterOperator == FilterOperatorEnum.IsNotNull;
        }

        private bool IsEndDateTimeDisabled()
        {
            return _filterOperator != FilterOperatorEnum.BetweenInclusive && _filterOperator != FilterOperatorEnum.BetweenExclusive;
        }

        private void SetFilterValues()
        {
            if (!FilterState.Filters.TryGetValue(PropertyName, out var filterDescriptor))
            {
                _filterOperator = FilterOperatorEnum.None;
                _startDateTime = null;
                _endDateTime = null;

                return;
            }

            var dateFilterDescriptor = filterDescriptor as DateFilterDescriptor;

            if (dateFilterDescriptor == null)
            {
                _filterOperator = FilterOperatorEnum.None;
                _startDateTime = null;
                _endDateTime = null;

                return;
            }

            _filterOperator = dateFilterDescriptor.FilterOperator;
            _startDateTime = dateFilterDescriptor.StartDate?.DateTime;
            _endDateTime = dateFilterDescriptor.EndDate?.DateTime;
        }

        protected virtual Task ApplyFilterAsync()
        {
            var numericFilter = new DateFilterDescriptor
            {
                PropertyName = PropertyName,
                FilterOperator = _filterOperator,
                StartDate = _startDateTime,
                EndDate = _endDateTime,
            };

            return FilterState.AddFilterAsync(numericFilter);
        }

        protected virtual async Task RemoveFilterAsync()
        {
            _filterOperator = FilterOperatorEnum.None;
            _startDateTime = null;
            _endDateTime = null;

            await FilterState.RemoveFilterAsync(PropertyName);
        }
    }
}
