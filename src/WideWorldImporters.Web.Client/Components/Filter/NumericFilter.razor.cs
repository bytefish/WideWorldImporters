// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Components;
using WideWorldImporters.Shared.Models;

namespace WideWorldImporters.Web.Client.Components
{
    public partial class NumericFilter<TItem>
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
        /// Filter Options available for the NumericFilter.
        /// </summary>
        private readonly FilterOperatorEnum[] filterOperatorOptions = new[]
        {
            FilterOperatorEnum.None,
            FilterOperatorEnum.IsNull,
            FilterOperatorEnum.IsNotNull,
            FilterOperatorEnum.IsEqualTo,
            FilterOperatorEnum.IsNotEqualTo,
            FilterOperatorEnum.IsGreaterThan,
            FilterOperatorEnum.IsGreaterThanOrEqualTo,
            FilterOperatorEnum.IsLessThan,
            FilterOperatorEnum.IsLessThanOrEqualTo,
            FilterOperatorEnum.BetweenExclusive,
            FilterOperatorEnum.BetweenInclusive
        };

        private bool IsLowerValueDisabled()
        {
            return _filterOperator == FilterOperatorEnum.None
                || _filterOperator == FilterOperatorEnum.IsNull
                || _filterOperator == FilterOperatorEnum.IsNotNull;
        }

        private bool IsUpperValueDisabled()
        {
            return _filterOperator != FilterOperatorEnum.BetweenInclusive && _filterOperator != FilterOperatorEnum.BetweenExclusive;
        }

        protected double? _lowerValue { get; set; }

        protected double? _upperValue { get; set; }

        protected FilterOperatorEnum _filterOperator { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            SetFilterValues();
        }

        private void SetFilterValues()
        {
            if (!FilterState.Filters.TryGetValue(PropertyName, out var filterDescriptor))
            {
                _filterOperator = FilterOperatorEnum.None;
                _lowerValue = null;
                _upperValue = null;

                return;
            }

            var numericFilterDescriptor = filterDescriptor as NumericFilterDescriptor;

            if (numericFilterDescriptor == null)
            {
                _filterOperator = FilterOperatorEnum.None;
                _lowerValue = null;
                _upperValue = null;

                return;
            }

            _filterOperator = numericFilterDescriptor.FilterOperator;
            _lowerValue = numericFilterDescriptor.LowerValue;
            _upperValue = numericFilterDescriptor.UpperValue;
        }

        protected virtual Task ApplyFilterAsync()
        {
            var numericFilter = new NumericFilterDescriptor
            {
                PropertyName = PropertyName,
                FilterOperator = _filterOperator,
                LowerValue = _lowerValue,
                UpperValue = _upperValue,
            };

            return FilterState.AddFilterAsync(numericFilter);
        }

        protected virtual async Task RemoveFilterAsync()
        {
            _filterOperator = FilterOperatorEnum.None;
            _lowerValue = null;
            _upperValue = null;

            await FilterState.RemoveFilterAsync(PropertyName);
        }
    }
}
