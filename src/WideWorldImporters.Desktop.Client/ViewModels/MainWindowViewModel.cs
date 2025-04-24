using Microsoft.OData.Client;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using WideWorldImportersService;
using WpfDataGridFilter;
using WpfDataGridFilter.DynamicLinq;

namespace WideWorldImporters.Desktop.Client.ViewModels;
public partial class MainWindowViewModel : ObservableObject
{
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

    private async void DataGridState_DataGridStateChanged(object? sender, DataGridStateChangedEventArgs e)
    {
        await Dispatcher.CurrentDispatcher.InvokeAsync(async () =>
        {
            await Refresh();
        });
    }

    public MainWindowViewModel(DataGridState dataGridState)
    {
        // Creates a new WideWorldImporters Container to query the Service
        Container = new Container(new Uri("https://localhost:5000/odata"));
        
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
    }

    public void SetSkipTop()
    {
        DataGridState.SetSkipTop((CurrentPage - 1) * PageSize, PageSize);
    }

    public async Task Refresh()
    {
        await Dispatcher.CurrentDispatcher.InvokeAsync(async () =>
        {
            // If there's no Page Size, we don't need to load anything.
            if (PageSize == 0)
            {
                return;
            }

            // Get the Total Count, so we can update the First and Last Page. This 
            // is a blocking call and probably redundant. We need to check this
            // in a later version.
            TotalItemCount = Container.Customers
                .Expand(x => x.LastEditedByNavigation)
                .AsQueryable()
                .GetTotalItemCount(DataGridState);

            // If our current page is not beyond the last Page, we'll need to rerequest data. At
            // the moment this is going to trigger yet another query for the Count. Obviously that's
            // a big TODO for a better implementation.
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

            DataServiceQuery<Customer> dataServiceQuery = (DataServiceQuery<Customer>)Container.Customers
                .Expand(x => x.LastEditedByNavigation)
                .ApplyDataGridState(DataGridState);

            IEnumerable<Customer> filteredResult = await dataServiceQuery.ExecuteAsync();

            Customers = new ObservableCollection<Customer>(filteredResult);
        });
    }
}