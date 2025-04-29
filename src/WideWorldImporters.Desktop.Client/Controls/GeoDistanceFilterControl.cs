// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Windows.Controls;
using WpfDataGridFilter.Models;
using WpfDataGridFilter.Translations;
using WpfDataGridFilter.Controls;

namespace WideWorldImporters.Desktop.Client.Controls
{
    public class GeoDistanceFilterControl : BaseFilterControl<GeoDistanceFilterDescriptor>
    {
        /// <summary>
        /// Supported Filters for this Filter Control.
        /// </summary>
        public static readonly List<FilterOperator> SupportedFilterOperators =
        [
            GeographyFilter.FilterOperators.DistanceLessThan,
            GeographyFilter.FilterOperators.DistanceLessEqualThan,
            GeographyFilter.FilterOperators.DistanceGreaterThan,
            GeographyFilter.FilterOperators.DistanceGreaterEqualThan,
        ];

        #region Controls 

        ComboBox? FilterOperatorsComboBox;
        TextBox? LatitudeTextBox;
        TextBox? LongitudeTextBox;
        TextBox? DistanceTextBox;

        #endregion Controls

        public override string PropertyName { get; set; } = string.Empty;

        public List<Translation<FilterOperator>> FilterOperators { get; private set; } = [];

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            FilterOperatorsComboBox = GetTemplateChild("PART_FilterOperators") as ComboBox;
            LatitudeTextBox = GetTemplateChild("PART_LatitudeTextBox") as TextBox;
            LongitudeTextBox = GetTemplateChild("PART_LongitudeTextBox") as TextBox;
            DistanceTextBox = GetTemplateChild("PART_DistanceTextBox") as TextBox;

            // Translations for the Control
            FilterOperators = GetFilterOperatorTranslations(Translations, SupportedFilterOperators);

            if (FilterOperatorsComboBox != null)
            {
                FilterOperatorsComboBox.DisplayMemberPath = nameof(Translation<FilterOperator>.Text);
                FilterOperatorsComboBox.SelectedValuePath = nameof(Translation<FilterOperator>.Value);
                FilterOperatorsComboBox.ItemsSource = FilterOperators;
            }

            if (DataGridState != null)
            {
                OnDataGridStateChanged();
            }
        }

        protected override void OnDataGridStateChanged()
        {
            GeoDistanceFilterDescriptor filterDescriptor = GetFilterDescriptor(DataGridState, PropertyName);

            if (FilterOperatorsComboBox != null)
            {
                FilterOperatorsComboBox.SelectedValue = filterDescriptor.FilterOperator;
            }

            if (LatitudeTextBox != null)
            {
                LatitudeTextBox.Text = filterDescriptor.Latitude?.ToString();
            }

            if (LongitudeTextBox != null)
            {
                LongitudeTextBox.Text = filterDescriptor.Longitude?.ToString();
            }
        }

        protected override void OnApplyFilter()
        {
            // Nothing to do...
        }

        protected override void OnResetFilter()
        {
            // Nothing to do...
        }

        protected override GeoDistanceFilterDescriptor GetDefaultFilterDescriptor()
        {
            return new GeoDistanceFilterDescriptor
            {
                PropertyName = PropertyName,
                FilterOperator = FilterOperator.None,
            };
        }

        protected override FilterDescriptor GetFilterDescriptor()
        {
            return new GeoDistanceFilterDescriptor
            {
                PropertyName = PropertyName,
                FilterOperator = GetCurrentFilterOperator(),
                Latitude = GetDoubleValue(LatitudeTextBox?.Text),
                Longitude = GetDoubleValue(LongitudeTextBox?.Text),
                Distance = GetDoubleValue(DistanceTextBox?.Text),
            };
        }

        private double? GetDoubleValue(string? value)
        {
            if (!double.TryParse(value, out double result))
            {
                return null;
            }

            return result;
        }

        private FilterOperator GetCurrentFilterOperator()
        {
            if (FilterOperatorsComboBox == null)
            {
                return FilterOperator.None;
            }

            if (FilterOperatorsComboBox.SelectedValue == null)
            {
                return FilterOperator.None;
            }

            FilterOperator currentFilterOperator = (FilterOperator)FilterOperatorsComboBox.SelectedValue;

            return currentFilterOperator;
        }

        protected override List<Translation<FilterOperator>> GetAdditionalTranslations()
        {
            return GeographyFilter.Translations.FilterOperatorTranslations;
        }
    }
}