// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using WideWorldImporters.Desktop.Client.ViewModels;
using WpfDataGridFilter;

namespace WideWorldImporters.Desktop.Client;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindowViewModel ViewModel { get; set; }

    public MainWindow()
    {
        ViewModel = new MainWindowViewModel(new DataGridState([]));
        DataContext = this;

        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        ViewModel.OnLoaded();
    }

    private void Window_Unloaded(object sender, RoutedEventArgs e)
    {
        ViewModel.OnUnloaded();
    }
}
