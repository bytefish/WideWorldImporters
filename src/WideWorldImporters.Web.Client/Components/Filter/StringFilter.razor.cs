// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Components;
using WideWorldImporters.Web.Client.Models;

namespace WideWorldImporters.Web.Client.Components
{
    public partial class StringFilter
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
        /// Filter Options available for the String Filter.
        /// </summary>
        private readonly FilterOperatorEnum[] filterOperatorOptions = new[]
        {
            FilterOperatorEnum.IsEmpty,
            FilterOperatorEnum.IsNotEmpty,
            FilterOperatorEnum.IsNull,
            FilterOperatorEnum.IsNotNull,
            FilterOperatorEnum.IsEqualTo,
            FilterOperatorEnum.IsNotEqualTo,
            FilterOperatorEnum.Contains,
            FilterOperatorEnum.NotContains,
            FilterOperatorEnum.StartsWith,
            FilterOperatorEnum.EndsWith,
        };

        private bool IsValueDisabled()
        {
            return _filterOperator == FilterOperatorEnum.None
                || _filterOperator == FilterOperatorEnum.IsNull
                || _filterOperator == FilterOperatorEnum.IsNotNull;
        }

        protected string? _value { get; set; }

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
                _value = null;

                return;
            }

            var stringFilterDescriptor = filterDescriptor as StringFilterDescriptor;

            if (stringFilterDescriptor == null)
            {
                _filterOperator = FilterOperatorEnum.None;
                _value = null;

                return;
            }

            _filterOperator = stringFilterDescriptor.FilterOperator;
            _value = stringFilterDescriptor.Value;
        }

        protected virtual Task ApplyFilterAsync()
        {
            var stringFilter = new StringFilterDescriptor
            {
                PropertyName = PropertyName,
                FilterOperator = _filterOperator,
                Value = _value
            };

            return FilterState.AddFilterAsync(stringFilter);
        }

        protected virtual async Task RemoveFilterAsync()
        {
            _filterOperator = FilterOperatorEnum.None;
            _value = null;

            await FilterState.RemoveFilterAsync(PropertyName);
        }
    }
}
