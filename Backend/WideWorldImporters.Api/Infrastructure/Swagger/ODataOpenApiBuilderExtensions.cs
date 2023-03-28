// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WideWorldImporters.Api.Infrastructure.Swagger
{
    /// <summary>
    /// Provides extension methods for <see cref="IApplicationBuilder"/> to add OData routes.
    /// </summary>
    public static class ODataOpenApiBuilderExtensions
    {
        /// <summary>
        /// Use OData OpenApi middleware.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder "/> to use.</param>
        /// <returns>The <see cref="IApplicationBuilder "/>.</returns>
        public static IApplicationBuilder UseODataOpenApi(this IApplicationBuilder app)
        {
            return app.UseODataOpenApi(route: "$openapi");
        }

        /// <summary>
        /// Use OData OpenApi middleware.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder "/> to use.</param>
        /// <param name="route">The route name used to query the openapi.</param>
        /// <returns>The <see cref="IApplicationBuilder "/>.</returns>
        public static IApplicationBuilder UseODataOpenApi(this IApplicationBuilder app, string route)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (string.IsNullOrWhiteSpace(route))
            {
                throw new ArgumentNullException(nameof(route));
            }

            return app.UseMiddleware<ODataOpenApiMiddleware>(route);
        }
    }
}