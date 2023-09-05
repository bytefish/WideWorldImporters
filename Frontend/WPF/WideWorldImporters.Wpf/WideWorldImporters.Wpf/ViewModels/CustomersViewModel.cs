// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Threading;
using CommunityToolkit.Mvvm.Input;
using System.Linq;
using System.Collections.ObjectModel;
using WideWorldImportersService;
using Microsoft.OData.Client;
using WideWorldImporters.Wpf.Models;
using WideWorldImporters.Wpf.Extensions;
using System.Windows;

namespace WideWorldImporters.Wpf.ViewModels
{
    public class CustomersViewModel : ObservableObject
    {
        /// <summary>
        /// The WideWorldImporters Context
        /// </summary>
        private Container _context = null!;

        /// <summary>
        /// The collection of customers in the list. 
        /// </summary>
        public ObservableCollection<CustomerViewModel> Customers { get; } = new ObservableCollection<CustomerViewModel>();

        /// <summary>
        /// Currently selected Customer.
        /// </summary>
        private CustomerViewModel? _selectedCustomer;

        /// <summary>
        /// Gets or sets the selected customer, or null if no customer is selected. 
        /// </summary>
        public CustomerViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
        }

        private SortColumn[] _sortColumns;

        /// <summary>
        /// Gets or sets a value indicating whether the Customers list is currently being updated. 
        /// </summary>
        public SortColumn[] SortColumns
        {
            get => _sortColumns;
            set 
            {
                SetProperty(ref _sortColumns, value);
                Refresh();
            }
        }

        private bool _isLoading;

        /// <summary>
        /// Gets or sets a value indicating whether the Customers list is currently being updated. 
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            private set => SetProperty(ref _isLoading, value);
        }

        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set
            {
                SetProperty(ref _pageSize, value);
                Refresh();
            }
        }

        private int _pageNumber;

        public int PageNumber
        {
            get => _pageNumber;
            private set => SetProperty(ref _pageNumber, value);
        }

        private int _pageCount;

        public int PageCount
        {
            get => _pageCount;
            private set => SetProperty(ref _pageCount, value);
        }

        public List<int> PageSizes => new() { 5, 10, 20, 50, 100 };

        public CustomersViewModel()
        {
            // Set default sort columns for the initial data load:
            _sortColumns = new SortColumn[]
            {
                new SortColumn("CustomerId", SortDirection.Ascending)
            };

            // Creates the OData Client, that will be used to query the 
            // OData Service. All changes to the underlying model are
            // tracked in the Context.
            //
            // This makes saving changes a no-brainer.
            _context = new Container(new Uri("http://localhost:5000/odata"));

            // We will just override all changes with the most recent data
            _context.MergeOption = MergeOption.OverwriteChanges;

            // Events to Load the Data
            FirstPageCommand = new AsyncRelayCommand(
                (ct) => GetCustomersAsync(1, _pageSize, _sortColumns,ct),
                () => _pageNumber != 1);

            PreviousPageCommand = new AsyncRelayCommand(
                (ct) => GetCustomersAsync(_pageNumber - 1, _pageSize, _sortColumns, ct),
                () => _pageNumber > 1);

            NextPageCommand = new AsyncRelayCommand(
                (ct) => GetCustomersAsync(_pageNumber + 1, _pageSize, _sortColumns, ct),
                () => _pageNumber < _pageCount);

            LastPageCommand = new AsyncRelayCommand(
                (ct) => GetCustomersAsync(_pageCount, _pageSize, _sortColumns, ct),
                () => _pageNumber != _pageCount);

            RefreshDataCommand = new AsyncRelayCommand(
                (ct) => GetCustomersAsync(_pageNumber, _pageSize, _sortColumns, ct),
                () => true);

            SaveChangesCommand = new AsyncRelayCommand(
                (ct) => SaveChangesAsync(ct),
                () => Customers.Any(x => x.IsModified));

            Refresh();
        }

        public IAsyncRelayCommand SaveChangesCommand { get; }

        public IAsyncRelayCommand RefreshDataCommand { get; }

        public IAsyncRelayCommand FirstPageCommand { get; }

        public IAsyncRelayCommand PreviousPageCommand { get; }

        public IAsyncRelayCommand NextPageCommand { get; }

        public IAsyncRelayCommand LastPageCommand { get; }

        private void Refresh()
        {
            _pageNumber = 0;
            FirstPageCommand.Execute(null);
        }


        private async Task GetCustomersAsync(int pageNumber, int pageSize, SortColumn[] sortColumns, CancellationToken cancellationToken)
        {
            try
            {
                // Signal, that we are loading the data:
                IsLoading = true;

                // Query the OData Endpoint:
                var response = (QueryOperationResponse<Customer>)await GetDataServiceQuery(sortColumns, pageNumber, pageSize).ExecuteAsync(cancellationToken);

                if (response.Error != null)
                {
                    return;
                }

                // Do not try to merge the Customers, we will just override them:
                Customers.Clear();

                foreach (var c in response.ToList())
                {
                    Customers.Add(new CustomerViewModel(c, SetModified));
                }

                // Once we have loaded the data, run the initial validation so the Grid refreshes:
                foreach (var c in Customers)
                {
                    c.Validate();
                }

                // Adjust the Page number and Page count with the Query results:
                PageNumber = pageNumber;
                PageCount = (int)response.Count / pageSize;

                // Notify all Event Handlers:
                FirstPageCommand.NotifyCanExecuteChanged();
                PreviousPageCommand.NotifyCanExecuteChanged();
                NextPageCommand.NotifyCanExecuteChanged();
                LastPageCommand.NotifyCanExecuteChanged();
                RefreshDataCommand.NotifyCanExecuteChanged();
                SaveChangesCommand.NotifyCanExecuteChanged();
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    caption: "Unexpected Error",
                    messageBoxText: $"Load customers failed (Details = {e.Message})");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private DataServiceQuery<Customer> GetDataServiceQuery(SortColumn[] sortColumns, int pageNumber, int pageSize)
        {
            var query = _context.Customers.Expand(x => x.LastEditedByNavigation)
                .WithPagination(pageNumber, pageSize)
                .SortBy(sortColumns)
                .IncludeCount(true);

            return (DataServiceQuery<Customer>)query;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _context.SaveChangesAsync(cancellationToken);

                await GetCustomersAsync(_pageNumber, _pageSize, _sortColumns, cancellationToken);
            } 
            catch(Exception e)
            {
                MessageBox.Show(
                    caption: "Unexpected Error",
                    messageBoxText: $"Save customers failed (Details = {e.Message})");
            } 
            finally
            {
                SaveChangesCommand.NotifyCanExecuteChanged();
            }
        }

        private void SetModified(Customer customer)
        {
            _context.ChangeState(customer, EntityStates.Modified);

            SaveChangesCommand.NotifyCanExecuteChanged();
        }
    }
}
