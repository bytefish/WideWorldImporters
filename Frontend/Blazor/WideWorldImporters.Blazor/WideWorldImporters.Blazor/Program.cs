using WideWorldImporters.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Fast.Components.FluentUI;
using Microsoft.OData.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// OData
builder.Services.AddScoped(sp =>
{
    return new WideWorldImportersService.Container(new Uri("http://localhost:5000/odata"))
    {
        HttpRequestTransportMode = HttpRequestTransportMode.HttpClient
    };
});

builder.Services.AddLocalization();

builder.Services.AddFluentUIComponents(options =>
{
    options.HostingModel = BlazorHostingModel.WebAssembly;
});

//When using icons and/or emoji replace the line above with the code below
//LibraryConfiguration config = new(ConfigurationGenerator.GetIconConfiguration(), ConfigurationGenerator.GetEmojiConfiguration());
//builder.Services.AddFluentUIComponents(config);

await builder.Build().RunAsync();
