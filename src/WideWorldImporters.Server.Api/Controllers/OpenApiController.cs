// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.OData;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OData.Edm;
using WideWorldImporters.Server.Api.Models;
using WideWorldImporters.Server.Api.Infrastructure.Errors;

namespace WideWorldImporters.Server.Api.Controllers
{
    /// <summary>
    /// This Controller exposes an Endpoint for the OpenAPI Schema, which will be generated from an <see cref="IEdmModel"/>.
    /// </summary>
    public class OpenApiController : ControllerBase
    {
        private readonly ILogger<OpenApiController> _logger;

        private readonly ApplicationErrorHandler _applicationErrorHandler;

        public OpenApiController(ILogger<OpenApiController> logger, ApplicationErrorHandler applicationErrorHandler)
        {
            _logger = logger;
            _applicationErrorHandler = applicationErrorHandler;
        }

        [HttpGet("odata/openapi.json")]
        public IActionResult GetOpenApiJson()
        {
            try
            {
                var edmModel = ApplicationEdmModel.GetEdmModel();

                var openApiSettings = new OpenApiConvertSettings
                {
                    ServiceRoot = new("https://localhost:5000"),
                    PathPrefix = "odata",
                    EnableKeyAsSegment = true,
                };

                var openApiDocument = edmModel.ConvertToOpenApi(openApiSettings);

                var openApiDocumentAsJson = openApiDocument.SerializeAsJson(OpenApiSpecVersion.OpenApi3_0);

                return Content(openApiDocumentAsJson, "application/json");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to generate the OpenAPI Schema from the EDM Schema");

                return _applicationErrorHandler.HandleException(HttpContext, ex);
            }
        }
    }
}