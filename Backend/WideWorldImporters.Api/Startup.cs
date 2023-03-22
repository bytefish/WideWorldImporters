// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.AspNetCore.OData.Query.Expressions;
using Microsoft.EntityFrameworkCore;
using WideWorldImporters.Api.Infrastructure.Spatial.Binder;
using WideWorldImporters.Api.Models;
using WideWorldImporters.Database;

namespace WideWorldImporters.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Register DbContexts:
            services.AddDbContext<WideWorldImportersContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=WideWorldImporters;Trusted_Connection=True;", o => o.UseNetTopologySuite());
            });

            // Enable Cors:
            services.AddCors();

            // Swagger:
            services.AddSwaggerGen();
            
            // Register ASP.NET Core Mvc:
            services
                // Register Web API Routes:
                .AddControllers()
                // Customize the Json Output, so we can serialize and deserialize the data:
                .AddJsonOptions(options =>
                {
                    // Ignore objects when cycles have been detected in deserialization:
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                })
                // Register OData Routes:
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/odata/swagger.json", "WideWorldImporters OData API");
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseODataBatching();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}