// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.Extensions.Options;
using Microsoft.OData;
using System.Net;
using WideWorldImporters.Api.Infrastructure.Exceptions;
using WideWorldImporters.Api.Infrastructure.Logging;
using WideWorldImporters.Api.Infrastructure.OData;

namespace WideWorldImporters.Api.Infrastructure.Errors
{

    /// <summary>
    /// Handles errors returned by the application.
    /// </summary>
    public class ApplicationErrorHandler
    {
        private readonly ILogger<ApplicationErrorHandler> _logger;

        private readonly ApplicationErrorHandlerOptions _options;

        public ApplicationErrorHandler(ILogger<ApplicationErrorHandler> logger, IOptions<ApplicationErrorHandlerOptions> options)
        {
            _logger = logger;
            _options = options.Value;
        }

        public ActionResult HandleInvalidModelState(HttpContext httpContext, ModelStateDictionary modelStateDictionary)
        {
            _logger.TraceMethodEntry();

            ODataError error = new ODataError()
            {
                ErrorCode = ErrorCodes.BadRequest,
                Message = "One or more validation errors occured",
                Details = GetODataErrorDetails(modelStateDictionary),
            };

            // If we have something like a Deserialization issue, the ModelStateDictionary has
            // a lower-level Exception. We cannot do anything sensible with exceptions, so 
            // we add them to the InnerError.
            var firstException = GetFirstException(modelStateDictionary);

            AddInnerError(httpContext, error, firstException);

            return new BadRequestObjectResult(error);
        }

        private Exception? GetFirstException(ModelStateDictionary modelStateDictionary)
        {
            _logger.TraceMethodEntry();

            foreach (var modelStateEntry in modelStateDictionary)
            {
                foreach (var modelError in modelStateEntry.Value.Errors)
                {
                    if (modelError.Exception != null)
                    {
                        return modelError.Exception;
                    }
                }
            }

            return null;
        }

        private List<ODataErrorDetail> GetODataErrorDetails(ModelStateDictionary modelStateDictionary)
        {
            _logger.TraceMethodEntry();

            // Validation Details
            var result = new List<ODataErrorDetail>();

            foreach (var modelStateEntry in modelStateDictionary)
            {
                foreach (var modelError in modelStateEntry.Value.Errors)
                {
                    // We cannot make anything sensible for the caller here. We log it, but then go on 
                    // as if nothing has happened. Alternative is to populate a chain of ODataInnerError 
                    // or abuse the ODataErrorDetails...
                    if (modelError.Exception != null)
                    {
                        _logger.LogError(modelError.Exception, "Invalid ModelState due to an exception");

                        continue;
                    }

                    // A ModelStateDictionary has nothing like an "ErrorCode" and it's not 
                    // possible with existing infrastructure to get an "ErrorCode" here. So 
                    // we set a generic one.
                    var errorCode = ErrorCodes.ValidationFailed;

                    var odataErrorDetail = new ODataErrorDetail
                    {
                        ErrorCode = errorCode,
                        Message = modelError.ErrorMessage,
                        Target = modelStateEntry.Key,
                    };

                    result.Add(odataErrorDetail);
                }
            }

            return result;
        }

        public ActionResult HandleException(HttpContext httpContext, Exception exception)
        {
            _logger.TraceMethodEntry();

            _logger.LogError(exception, "Call to '{RequestPath}' failed due to an Exception", httpContext.Request.Path);

            return exception switch
            {
                AuthenticationFailedException e => HandleAuthenticationException(httpContext, e),
                EntityConcurrencyException e => HandleEntityConcurrencyException(httpContext, e),
                EntityNotFoundException e => HandleEntityNotFoundException(httpContext, e),
                EntityUnauthorizedAccessException e => HandleEntityUnauthorizedException(httpContext, e),
                Exception e => HandleSystemException(httpContext, e)
            };
        }

        private ActionResult HandleAuthenticationException(HttpContext httpContext, AuthenticationFailedException e)
        {
            _logger.TraceMethodEntry();

            var error = new ODataError
            {
                ErrorCode = ErrorCodes.AuthenticationFailed,
                Message = e.ErrorMessage,
            };

            AddInnerError(httpContext, error, e);

            return new UnauthorizedODataResult(error);
        }

        private ActionResult HandleEntityConcurrencyException(HttpContext httpContext, EntityConcurrencyException e)
        {
            _logger.TraceMethodEntry();

            var error = new ODataError
            {
                ErrorCode = e.ErrorCode,
                Message = e.ErrorMessage,
            };

            AddInnerError(httpContext, error, e);

            return new ConflictODataResult(error);
        }

        private ActionResult HandleEntityNotFoundException(HttpContext httpContext, EntityNotFoundException e)
        {
            _logger.TraceMethodEntry();

            var error = new ODataError
            {
                ErrorCode = e.ErrorCode,
                Message = e.ErrorMessage,
            };

            AddInnerError(httpContext, error, e);

            return new NotFoundODataResult(error);
        }

        private ActionResult HandleEntityUnauthorizedException(HttpContext httpContext, EntityUnauthorizedAccessException e)
        {
            _logger.TraceMethodEntry();

            var error = new ODataError
            {
                ErrorCode = e.ErrorCode,
                Message = e.ErrorMessage,
            };

            AddInnerError(httpContext, error, e);

            return new ForbiddenODataResult(error);
        }

        private ActionResult HandleSystemException(HttpContext httpContext, Exception e)
        {
            _logger.TraceMethodEntry();

            var error = new ODataError
            {
                ErrorCode = ErrorCodes.InternalServerError,
                Message = "An Internal Server Error occured"
            };

            AddInnerError(httpContext, error, e);

            return new ObjectResult(error)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
            };
        }

        private void AddInnerError(HttpContext httpContext, ODataError error, Exception? e)
        {
            _logger.TraceMethodEntry();

            error.InnerError = new ODataInnerError();

            error.InnerError.Properties["trace-id"] = new ODataPrimitiveValue(httpContext.TraceIdentifier);

            if (e != null && _options.IncludeExceptionDetails)
            {
                error.InnerError.Message = e.Message;
                error.InnerError.StackTrace = e.StackTrace;
                error.InnerError.TypeName = e.GetType().Name;
            }
        }
    }
}