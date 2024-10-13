// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.ComponentModel;
using System.DirectoryServices;
using System.Windows.Controls;
using WideWorldImporters.Shared.Models;
using Wpf.Ui.Controls;

namespace WideWorldImporters.Desktop.Client.Views.Pages;

/// <summary>
/// Interaction logic for DataView.xaml
/// </summary>
public partial class CustomersPage : INavigableView<ViewModels.CustomersViewModel>
{
    private static string[] columnToODataProperty = new[]
    {
        "CustomerId",
        "CustomerName",
        "PhoneNumber",
        "FaxNumber",
        "LastEditedByNavigation/PreferredName"
    };

    public ViewModels.CustomersViewModel ViewModel { get; }

    public CustomersPage(ViewModels.CustomersViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }

    private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        ViewModel.SelectedCustomer?.Validate();
    }

    private void DataGrid_Sorted(object sender, RoutedEventArgs e)
    {

    }

    private ListSortDirection? lastSortDirection;

    private string? lastSortMemberPath;

    private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
    {
        e.Handled = true;

        // Keep Track of the previous Sort Column and Sort Direction:
        if (e.Column.SortMemberPath == lastSortMemberPath)
        {
            if (lastSortDirection == ListSortDirection.Ascending)
            {
                e.Column.SortDirection = ListSortDirection.Descending;
            }
            else
            {
                e.Column.SortDirection = ListSortDirection.Ascending;
            }
        }
        else
        {
            e.Column.SortDirection = ListSortDirection.Ascending;
        }

        lastSortDirection = e.Column.SortDirection;
        lastSortMemberPath = e.Column.SortMemberPath;

        // Get all Columns from the DataGrid:
        var columns = ((Wpf.Ui.Controls.DataGrid)sender).Columns;

        // Get all Sort Columns:
        var sortColumns = columns
            // Only use Columns, that have been sorted
            .Where(column => column.SortDirection != null)
            // Convert to Model:
            .Select(column =>
            {
                var propertyName = columnToODataProperty[column.DisplayIndex];
                var sortDirection = column.SortDirection == System.ComponentModel.ListSortDirection.Descending ? SortDirectionEnum.Descending : SortDirectionEnum.Ascending;

                return new SortColumn
                {
                    PropertyName = propertyName,
                    SortDirection = sortDirection
                };
            })
            .ToList();


        ViewModel.SortColumns = sortColumns;
    }

}
