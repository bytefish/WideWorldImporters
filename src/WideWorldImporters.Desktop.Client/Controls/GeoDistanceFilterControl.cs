// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Windows.Controls;
using WpfDataGridFilter.Infrastructure;
using WpfDataGridFilter;
using WpfDataGridFilter.Models;
using WpfDataGridFilter.Translations;

namespace WideWorldImporters.Desktop.Client.Controls
{
    public class GeoDistanceFilterControl : FilterControl
    {
        public static FilterType GeoDistanceFilterType = new FilterType { Name = "GeoDistanceFilter" };

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

        Button? ApplyButton;
        Button? ResetButton;
        ComboBox? FilterOperatorsComboBox;
        TextBox? LatitudeTextBox;
        TextBox? LongitudeTextBox;
        TextBox? DistanceTextBox;

        #endregion Controls

        public override string PropertyName { get; set; } = string.Empty;

        public List<Translation<FilterOperator>> FilterOperators { get; private set; } = [];

        /// <summary>  
        ///  Translations
        /// </summary>
        public override ITranslations Translations
        {
            get { return (ITranslations)GetValue(TranslationsProperty); }
            set { SetValue(TranslationsProperty, value); }
        }

        public static readonly DependencyProperty TranslationsProperty = DependencyProperty.Register(
            "Translations", typeof(ITranslations), typeof(GeoDistanceFilterControl), new PropertyMetadata(new NeutralTranslations(), OnTranslationsChanged));

        private static void OnTranslationsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is GeoDistanceFilterControl control)
            {
                control.Translations = (ITranslations)e.NewValue;
            }
        }

        /// <summary>  
        ///  FilterState of the current DataGrid.
        /// </summary>
        public override DataGridState DataGridState
        {
            get { return (DataGridState)GetValue(DataGridStateProperty); }
            set { SetValue(DataGridStateProperty, value); }
        }

        public static readonly DependencyProperty DataGridStateProperty = DependencyProperty.Register(
            "DataGridState", typeof(DataGridState), typeof(GeoDistanceFilterControl), new PropertyMetadata(propertyChangedCallback: OnDataGridStateChanged));

        private static void OnDataGridStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is GeoDistanceFilterControl control)
            {
                control.DataGridState = (DataGridState)e.NewValue;

                control.RefreshFilterDescriptor();
            }
        }

        /// <summary>
        /// Creates a FilterDescriptor this Control describes.
        /// </summary>
        public override FilterDescriptor FilterDescriptor => new GeoDistanceFilterDescriptor
        {
            PropertyName = PropertyName,
            FilterOperator = GetCurrentFilterOperator(),
            Latitude = GetDoubleValue(LatitudeTextBox?.Text),
            Longitude = GetDoubleValue(LongitudeTextBox?.Text),
            Distance = GetDoubleValue(DistanceTextBox?.Text),
        };

        /// <summary>
        /// Gets the Filter Descriptor off of the DataGridState or creates a new one.
        /// </summary>
        /// <param name="dataGridState">DataGridState with Filters</param>
        /// <param name="propertyName">PropertyName</param>
        /// <returns>The existing FilterDescriptor or a new one</returns>
        private GeoDistanceFilterDescriptor GetFilterDescriptor(DataGridState dataGridState, string propertyName)
        {
            if (!dataGridState.TryGetFilter<GeoDistanceFilterDescriptor>(propertyName, out var descriptor))
            {
                return new GeoDistanceFilterDescriptor
                {
                    PropertyName = propertyName,
                    FilterOperator = FilterOperator.None,
                };
            }

            return descriptor;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            ApplyButton = GetTemplateChild("PART_ApplyButton") as Button;
            ResetButton = GetTemplateChild("PART_ResetButton") as Button;
            FilterOperatorsComboBox = GetTemplateChild("PART_FilterOperators") as ComboBox;
            LatitudeTextBox = GetTemplateChild("PART_LatitudeTextBox") as TextBox;
            LongitudeTextBox = GetTemplateChild("PART_LongitudeTextBox") as TextBox;
            DistanceTextBox = GetTemplateChild("PART_DistanceTextBox") as TextBox;

            // Translations for the Control
            FilterOperators = GetTranslations(Translations, SupportedFilterOperators);

            if (FilterOperatorsComboBox != null)
            {
                FilterOperatorsComboBox.DisplayMemberPath = nameof(Translation<FilterOperator>.Text);
                FilterOperatorsComboBox.SelectedValuePath = nameof(Translation<FilterOperator>.Value);
                FilterOperatorsComboBox.ItemsSource = FilterOperators;
            }

            if (ApplyButton != null)
            {
                ApplyButton.Click -= OnApplyButtonClick;
                ApplyButton.Click += OnApplyButtonClick;

                ApplyButton.Content = Translations.ApplyButton;
            }

            if (ResetButton != null)
            {
                ResetButton.Click -= OnResetButtonClick;
                ResetButton.Click += OnResetButtonClick;

                ResetButton.Content = Translations.ResetButton;
            }

            if (DataGridState != null)
            {
                RefreshFilterDescriptor();
            }
        }

        private void RefreshFilterDescriptor()
        {
            GeoDistanceFilterDescriptor filterDescriptor = GetFilterDescriptor(DataGridState, PropertyName);

            if (FilterOperatorsComboBox != null)
            {
                FilterOperatorsComboBox.SelectedValue = filterDescriptor.FilterOperator;
            }

            if (LatitudeTextBox != null)
            {
                LatitudeTextBox.Text = filterDescriptor.Latitude.ToString();
            }

            if (LongitudeTextBox != null)
            {
                LongitudeTextBox.Text = filterDescriptor.Longitude.ToString();
            }

            if (DistanceTextBox != null)
            {
                DistanceTextBox.Text = filterDescriptor.Distance.ToString();
            }
        }

        private List<Translation<FilterOperator>> GetTranslations(ITranslations translations, List<FilterOperator> source)
        {
            // Merge Defaults and User-supplied Filter Operators
            List<Translation<FilterOperator>> filterOperatorTranslations =
            [
                ..translations.FilterOperatorTranslations,
                ..GeographyFilter.Translations.FilterOperatorTranslations
            ];

            // Now just iterate over it. Missing Translations will throw, and I guess that's OK
            List<Translation<FilterOperator>> results = [];

            foreach (var enumValue in source)
            {
                Translation<FilterOperator> translation = filterOperatorTranslations.First(t => t.Value == enumValue);

                results.Add(translation);
            }

            return results;
        }

        private void OnResetButtonClick(object sender, RoutedEventArgs e)
        {
            DataGridState.RemoveFilter(PropertyName);

            if (FilterOperatorsComboBox != null)
            {
                FilterOperatorsComboBox.SelectedValue = FilterOperator.None;
            }

            if (LatitudeTextBox != null)
            {
                LatitudeTextBox.Text = null;
            }

            if (LongitudeTextBox != null)
            {
                LongitudeTextBox.Text = null;
            }

            if (DistanceTextBox != null)
            {
                DistanceTextBox.Text = null;
            }
        }

        private void OnApplyButtonClick(object sender, RoutedEventArgs e)
        {
            DataGridState.AddFilter(FilterDescriptor);
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
    }
}