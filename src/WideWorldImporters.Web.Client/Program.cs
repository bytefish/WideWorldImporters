// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using WideWorldImporters.Shared.ApiSdk;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add the Kiota Client.
builder.Services.AddScoped<IAuthenticationProvider, AnonymousAuthenticationProvider>();

builder.Services
    .AddHttpClient<IRequestAdapter, HttpClientRequestAdapter>(client => client.BaseAddress = new Uri("https://localhost:5000"));

builder.Services.AddScoped<ApiClient>();

// Localization
builder.Services.AddLocalization();

// Fluent UI
builder.Services.AddFluentUIComponents();

await builder.Build().RunAsync();
