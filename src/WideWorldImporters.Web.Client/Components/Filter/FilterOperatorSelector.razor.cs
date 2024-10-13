// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using WideWorldImporters.Web.Client.Localization;
using WideWorldImporters.Web.Client.Models;

namespace WideWorldImporters.Web.Client.Components
{
    public partial class FilterOperatorSelector
    {
        /// <summary>
        /// Localizer.
        /// </summary>
        [Inject]
        public IStringLocalizer<SharedResource> Loc { get; set; } = default!;

        /// <summary>
        /// Text used on aria-label attribute.
        /// </summary>
        [Parameter]
        public virtual string? Title { get; set; }

        /// <summary>
        /// If true, will disable the list of items.
        /// </summary>
        [Parameter]
        public virtual bool Disabled { get; set; } = false;

        /// <summary>
        /// Gets or sets the content to be rendered inside the component.
        /// In this case list of FluentOptions
        /// </summary>
        [Parameter]
        public virtual RenderFragment? ChildContent { get; set; }

        /// <summary>
        /// All selectable Filter Operators.
        /// </summary>
        [Parameter]
        public required FilterOperatorEnum[] FilterOperators { get; set; }

        /// <summary>
        /// The FilterOperator.
        /// </summary>
        [Parameter]
        public FilterOperatorEnum FilterOperator { get; set; }

        /// <summary>
        /// Invoked, when the Filter Operator has changed.
        /// </summary>
        [Parameter]
        public EventCallback<FilterOperatorEnum> FilterOperatorChanged { get; set; }

        /// <summary>
        /// Value.
        /// </summary>
        string? _value { get; set; }

        /// <summary>
        /// Filter Operator.
        /// </summary>
        private FilterOperatorEnum _filterOperator { get; set; }

        protected override void OnParametersSet()
        {
            _filterOperator = FilterOperator;
            _value = FilterOperator.ToString();
        }

        public void OnSelectedValueChanged(FilterOperatorEnum value)
        {
            _filterOperator = value;
            _value = value.ToString();

            FilterOperatorChanged.InvokeAsync(_filterOperator);
        }
    }
}