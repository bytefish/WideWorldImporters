// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.OData.Client;
using System.Collections.ObjectModel;
using WideWorldImporters.Desktop.Client.Controls;
using WideWorldImportersService;
using WpfDataGridFilter;
using WpfDataGridFilter.DynamicLinq;
using WpfDataGridFilter.DynamicLinq.Infrastructure;
using WpfDataGridFilter.Infrastructure;

namespace WideWorldImporters.Desktop.Client.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private IFilterControlProvider _filterControlProvider;

    [ObservableProperty]
    private IFilterTranslatorProvider _filterTranslatorProvider;

    [ObservableProperty]
    private ObservableCollection<Customer> _customers;

    [ObservableProperty]
    private DataGridState _dataGridState;

    [ObservableProperty]
    public int _currentPage = 1;

    public int LastPage => ((TotalItemCount - 1) / PageSize) + 1;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(LastPage))]
    private int _totalItemCount;

    [ObservableProperty]
    private List<int> _pageSizes = new() { 10, 25, 50, 100, 250 };

    private int _pageSize = 25;

    public int PageSize
    {
        get => _pageSize;
        set
        {
            if (SetProperty(ref _pageSize, value))
            {
                // We could also calculate the page, that contains 
                // the current element, but it's better to just set 
                // it to 1 I think.
                CurrentPage = 1;

                // The Last Page has changed, so we can update the 
                // UI. The Last Page is also used to determine the 
                // bounds.
                OnPropertyChanged(nameof(LastPage));

                // Update the Page.
                SetSkipTop();
            }
        }
    }

    public IRelayCommand FirstPageCommand { get; }

    public IRelayCommand PreviousPageCommand { get; }

    public IRelayCommand NextPageCommand { get; }

    public IRelayCommand LastPageCommand { get; }

    public IAsyncRelayCommand RefreshDataCommand { get; }

    public Container Container;

    public void OnLoaded()
    {
        DataGridState.DataGridStateChanged += DataGridState_DataGridStateChanged;

        SetSkipTop();
    }

    public void OnUnloaded()
    {
        DataGridState.DataGridStateChanged -= DataGridState_DataGridStateChanged;
    }

    private void DataGridState_DataGridStateChanged(object? sender, DataGridStateChangedEventArgs e)
    {
        RefreshDataCommand.Execute(null);
    }

    public MainWindowViewModel(DataGridState dataGridState)
    {
        // Creates a new WideWorldImporters Container to query the Service
        Container = new Container(new Uri("https://localhost:5000/odata"));

        // Create a Custom Filter Provider, which is able to resolve 
        (FilterControlProvider, FilterTranslatorProvider) = GetCustomProviders();

        // Holds the DataGridState for the Displayed DataGrid
        DataGridState = dataGridState;
        
        // Customers
        Customers = new ObservableCollection<Customer>([]);

        FirstPageCommand = new RelayCommand(() =>
        {
            CurrentPage = 1;
            SetSkipTop();
        },
        () => CurrentPage != 1);

        PreviousPageCommand = new RelayCommand(() =>
        {
            CurrentPage = CurrentPage - 1;
            SetSkipTop();
        },
        () => CurrentPage > 1);

        NextPageCommand = new RelayCommand(() =>
        {
            CurrentPage = CurrentPage + 1;
            SetSkipTop();
        },
        () => CurrentPage < LastPage);

        LastPageCommand = new RelayCommand(() =>
        {
            CurrentPage = LastPage;
            SetSkipTop();
        },
        () => CurrentPage != LastPage);

        RefreshDataCommand = new AsyncRelayCommand(
            execute: () => RefreshAsync(),
            canExecute: () => true);
    }

    public void SetSkipTop()
    {
        DataGridState.SetSkipTop((CurrentPage - 1) * PageSize, PageSize);
    }

    public async Task RefreshAsync()
    {

        // If there's no Page Size, we don't need to load anything.
        if (PageSize == 0)
        {
            return;
        }

        DataServiceQuery<Customer> dataServiceQuery = (DataServiceQuery<Customer>)Container.Customers
            .IncludeCount()
            .Expand(x => x.LastEditedByNavigation)
            .ApplyDataGridState(DataGridState, FilterTranslatorProvider);

        // Gets the Response and Data, as can be seen in the Query, we are also including the Count, so we don't run 
        // dozens of queries. We could also try to use the pagination functions of OData I guess.
        QueryOperationResponse<Customer> response = (QueryOperationResponse<Customer>)await dataServiceQuery.ExecuteAsync();
        
        // Get the Total Count, so we can update the First and Last Page.
        TotalItemCount = (int) response.Count;

        // If our current page is beyond the last Page, we'll need to rerequest data. It often means, that we didn't receive 
        // any data yet, so it shouldn't be too expensive to re-request everything again.
        if (CurrentPage > 0 && CurrentPage > LastPage)
        {
            // If the number of items has reduced such that the current page index is no longer valid, move
            // automatically to the final valid page index and trigger a further data load.
            CurrentPage = LastPage;

            SetSkipTop();

            return;
        }

        // Notify all Event Handlers, so we can enable or disable the 
        FirstPageCommand.NotifyCanExecuteChanged();
        PreviousPageCommand.NotifyCanExecuteChanged();
        NextPageCommand.NotifyCanExecuteChanged();
        LastPageCommand.NotifyCanExecuteChanged();

        IEnumerable<Customer> filteredResult = await dataServiceQuery.ExecuteAsync();

        Customers = new ObservableCollection<Customer>(filteredResult);
    }

    public static (IFilterControlProvider, IFilterTranslatorProvider)  GetCustomProviders()
    {
        // Build default Providers
        (FilterControlProvider filterControlProvider, FilterTranslatorProvider filterTranslatorProvider) = 
            (new FilterControlProvider(), new FilterTranslatorProvider());

        // Register custom hooks
        filterControlProvider
            .AddOrReplace(GeographyFilter.GeoDistanceFilterType, () => new GeoDistanceFilterControl());

        filterTranslatorProvider
            .AddOrReplace(new GeoDistanceFilterTranslator());

        return (filterControlProvider, filterTranslatorProvider);
    }
}