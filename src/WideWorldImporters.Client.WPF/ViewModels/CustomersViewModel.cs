// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.ObjectModel;
using WideWorldImporters.Client.Shared.Models;
using WideWorldImporters.Client.Shared.OData;
using WideWorldImporters.Shared.ApiSdk;
using WideWorldImporters.Shared.ApiSdk.Extensions;
using WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService;

namespace WideWorldImporters.Client.WPF.ViewModels
{
    public class CustomersViewModel : ObservableObject
    {
        /// <summary>
        /// API Client.
        /// </summary>
        private readonly ApiClient _apiClient;

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

        private List<FilterDescriptor> _filterDescriptors;

        /// <summary>
        /// Gets or sets a value indicating whether the Customers list is currently being updated. 
        /// </summary>
        public List<FilterDescriptor> FilterDescriptors
        {
            get => _filterDescriptors;
            set
            {
                SetProperty(ref _filterDescriptors, value);
                Refresh();
            }
        }

        private List<SortColumn> _sortColumns;

        /// <summary>
        /// Gets or sets a value indicating whether the Customers list is currently being updated. 
        /// </summary>
        public List<SortColumn> SortColumns
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

        public CustomersViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;

            // Set default sort columns for the initial data load:
            _filterDescriptors = [];

            _sortColumns =
            [
                new SortColumn {
                    PropertyName = "CustomerId",
                    SortDirection =  SortDirectionEnum.Ascending
                }
            ];

            // Events to Load the Data
            FirstPageCommand = new AsyncRelayCommand(
                (ct) => GetCustomersAsync(1, _pageSize, _sortColumns, ct),
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

        private async Task GetCustomersAsync(int pageNumber, int pageSize, List<SortColumn> sortColumns, CancellationToken cancellationToken)
        {
            try
            {
                // Signal, that we are loading the data:
                IsLoading = true;

                // Query the OData Endpoint:
                var response = await GetCustomersAsync(sortColumns, pageNumber, pageSize);

                if(response == null)
                {
                    return;
                }

                if (response.Value == null)
                {
                    return;
                }

                // Do not try to merge the Customers, we will just override them:
                Customers.Clear();

                foreach (var c in response.Value)
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
                PageCount = response.GetODataCount() / pageSize;

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

        private async Task<CustomerCollectionResponse?> GetCustomersAsync(List<SortColumn> sortColumns, int pageNumber, int itemsPerPage)
        {
            // Extract all Filters from the Blazor FluentUI DataGrid
            List<FilterDescriptor> filters = [];

            // Build the ODataQueryParameters using the ODataQueryParametersBuilder
            var parameters = ODataQueryParameters.Builder
                .SetPage(pageNumber, itemsPerPage)
                .SetFilter(filters)
                .AddExpand(nameof(Customer.LastEditedByNavigation))
                .AddOrderBy(sortColumns)
                .Build();

            // Get the Data using the ApiClient from the SDK
            return await _apiClient.Odata.Customers.GetAsync(request =>
            {
                request.QueryParameters.Count = true;

                request.QueryParameters.Top = parameters.Top;
                request.QueryParameters.Skip = parameters.Skip;

                if (parameters.Expand != null)
                {
                    request.QueryParameters.Expand = parameters.Expand;
                }

                if (!string.IsNullOrWhiteSpace(parameters.Filter))
                {
                    request.QueryParameters.Filter = parameters.Filter;
                }

                if (parameters.OrderBy != null)
                {
                    request.QueryParameters.Orderby = parameters.OrderBy;
                }
            });
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                // await _context.SaveChangesAsync(cancellationToken);

                await GetCustomersAsync(_pageNumber, _pageSize, _sortColumns, cancellationToken);
            }
            catch (Exception e)
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
            //_context.ChangeState(customer, EntityStates.Modified);

            SaveChangesCommand.NotifyCanExecuteChanged();
        }
    }
}
