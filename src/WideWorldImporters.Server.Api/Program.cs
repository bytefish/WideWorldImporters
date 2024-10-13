// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.AspNetCore.OData.Query.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using WideWorldImporters.Server.Database;
using WideWorldImporters.Server.Api.Infrastructure.Errors;
using WideWorldImporters.Server.Api.Infrastructure.Spatial;
using WideWorldImporters.Server.Api.Models;

// We will log to %LocalAppData%/LogWideWorldImporters to store the Logs, so it doesn't need to be configured 
// to a different path, when you run it on your machine.
string logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WideWorldImporters");

// We are writing with RollingFileAppender using a daily rotation, and we want to have the filename as 
// as "LogWideWorldImporters-{Date}.log", the "{Date}" placeholder will be replaced by Serilog itself.
string logFilePath = Path.Combine(logDirectory, "LogWideWorldImporters-.log");

// Configure the Serilog Logger. This Serilog Logger will be passed 
// to the Microsoft.Extensions.Logging LoggingBuilder using the 
// LoggingBuilder#AddSerilog(...) extension.
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .Enrich.WithEnvironmentName()
    .WriteTo.Console(theme: AnsiConsoleTheme.Code)
    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Configuration
    builder.Configuration
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables()
        .AddUserSecrets<Program>();

    // Database
    builder.Services.AddDbContext<WideWorldImportersContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("ApplicationDatabase");

        if (connectionString == null)
        {
            throw new InvalidOperationException("No ConnectionString named 'ApplicationDatabase' was found");
        }

        options
            .UseSqlServer(connectionString, o => o.UseNetTopologySuite())
            .EnableSensitiveDataLogging();
    });

    // Logging
    builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));


    // CORS
    builder.Services.AddCors(options =>
    {
        var allowedOrigins = builder.Configuration
            .GetSection("AllowedOrigins")
            .Get<string[]>();

        if (allowedOrigins == null)
        {
            throw new InvalidOperationException("AllowedOrigins is missing in the appsettings.json");
        }

        options.AddPolicy("CorsPolicy", builder => builder
            .WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
    });

    // Add Error Handler
    builder.Services.Configure<ApplicationErrorHandlerOptions>(o =>
    {
        o.IncludeExceptionDetails = builder.Environment.IsDevelopment() || builder.Environment.IsStaging();
    });

    builder.Services.AddSingleton<ApplicationErrorHandler>();


    builder.Services
        .AddControllers()
        .AddOData((opt) =>
        {
            opt.AddRouteComponents(
                routePrefix: "odata",
                model: ApplicationEdmModel.GetEdmModel(), configureServices: svcs =>
                {
                    svcs.AddSingleton<ODataBatchHandler>(new DefaultODataBatchHandler());
                    svcs.AddSingleton<IFilterBinder, GeoDistanceFilterBinder>();
                })
            .EnableQueryFeatures().Select().Expand().OrderBy().Filter().Count();
        });

    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // We want all Exceptions to return an ODataError in the Response. So all Exceptions should be handled and run through
    // this ExceptionHandler. This should only happen for things deep down in the ASP.NET Core stack, such as not resolving
    // routes.
    // 
    // Anything else should run through the Controllers and the Error Handlers are going to work there.
    //
    app.UseExceptionHandler(options =>
    {
        options.Run(async context =>
        {
            // Get the ExceptionHandlerFeature, so we get access to the original Exception
            var exceptionHandlerFeature = context.Features.GetRequiredFeature<IExceptionHandlerFeature>();

            // The ODataErrorHandler is required for adding an ODataError to all failed HTTP responses
            var odataErrorHandler = context.RequestServices.GetRequiredService<ApplicationErrorHandler>();

            // We can get the underlying Exception from the ExceptionHandlerFeature
            var exception = exceptionHandlerFeature.Error;

            // This isn't nice, because we probably shouldn't work with MVC types here. It would be better 
            // to rewrite the ApplicationErrorHandler to working with the HttpResponse.
            var actionContext = new ActionContext { HttpContext = context };

            var actionResult = odataErrorHandler.HandleException(context, exception);

            await actionResult
                .ExecuteResultAsync(actionContext)
                .ConfigureAwait(false);
        });
    });

    if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("https://localhost:5000/odata/openapi.json", "WideWorldImporters Service");
        });
    }

    app.UseCors("CorsPolicy");

    app.UseODataBatching();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    Log.Fatal(exception, "An unhandeled exception occured.");
}
finally
{
    // Wait 0.5 seconds before closing and flushing, to gather the last few logs.
    await Task.Delay(TimeSpan.FromMilliseconds(500));
    await Log.CloseAndFlushAsync();
}