// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.IO;
using System.Windows.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Http.HttpClientLibrary;
using WideWorldImporters.Client.WPF.Models;
using WideWorldImporters.Client.WPF.Services;
using WideWorldImporters.Shared.ApiSdk;
using Wpf.Ui;

namespace WideWorldImporters.Client.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    // The.NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    private static readonly IHost _host = Host.CreateDefaultBuilder()
        .ConfigureAppConfiguration(c =>
        {
            var basePath =
                Path.GetDirectoryName(AppContext.BaseDirectory)
                ?? throw new DirectoryNotFoundException(
                    "Unable to find the base directory of the application."
                );
            _ = c.SetBasePath(basePath);
        })
        .ConfigureServices(
            (context, services) =>
            {
                // App Host
                _ = services.AddHostedService<ApplicationHostService>();

                // API Client
                _ = services.AddScoped<IAuthenticationProvider, AnonymousAuthenticationProvider>();
                _ = services.AddHttpClient<IRequestAdapter, HttpClientRequestAdapter>(client => client.BaseAddress = new Uri("https://localhost:5000"));
                _ = services.AddScoped<ApiClient>();

                // Page resolver service
                _ = services.AddSingleton<IPageService, PageService>();

                // Theme manipulation
                _ = services.AddSingleton<IThemeService, ThemeService>();

                // TaskBar manipulation
                _ = services.AddSingleton<ITaskBarService, TaskBarService>();

                // Service containing navigation, same as INavigationWindow... but without window
                _ = services.AddSingleton<INavigationService, NavigationService>();

                // Main window with navigation
                _ = services.AddSingleton<INavigationWindow, Views.MainWindow>();
                _ = services.AddSingleton<ViewModels.MainWindowViewModel>();

                // Views and ViewModels
                _ = services.AddSingleton<Views.Pages.DashboardPage>();
                _ = services.AddSingleton<ViewModels.DashboardViewModel>();
                _ = services.AddSingleton<Views.Pages.DataPage>();
                _ = services.AddSingleton<ViewModels.DataViewModel>();
                _ = services.AddSingleton<Views.Pages.SettingsPage>();
                _ = services.AddSingleton<ViewModels.SettingsViewModel>();
                _ = services.AddSingleton<Views.Pages.CustomersPage>();
                _ = services.AddSingleton<ViewModels.CustomersViewModel>();

                // Configuration
                _ = services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
            }
        )
        .Build();

    /// <summary>
    /// Gets registered service.
    /// </summary>
    /// <typeparam name="T">Type of the service to get.</typeparam>
    /// <returns>Instance of the service or <see langword="null"/>.</returns>
    public static T? GetService<T>()
        where T : class
    {
        return _host.Services.GetService(typeof(T)) as T;
    }

    /// <summary>
    /// Occurs when the application is loading.
    /// </summary>
    private async void OnStartup(object sender, StartupEventArgs e)
    {
        await _host.StartAsync();
    }

    /// <summary>
    /// Occurs when the application is closing.
    /// </summary>
    private async void OnExit(object sender, ExitEventArgs e)
    {
        await _host.StopAsync();

        _host.Dispose();
    }

    /// <summary>
    /// Occurs when an exception is thrown by an application but not handled.
    /// </summary>
    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        // For more info see https://docs.microsoft.com/en-us/dotnet/api/system.windows.application.dispatcherunhandledexception?view=windowsdesktop-6.0
    }
}
