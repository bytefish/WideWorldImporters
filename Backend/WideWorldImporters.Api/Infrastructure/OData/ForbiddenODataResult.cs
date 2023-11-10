﻿// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.OData;

namespace WideWorldImporters.Api.Infrastructure.OData
{
    /// <summary>
    /// Represents a result that when executed will produce a Unauthorized (401) response.
    /// </summary>
    /// <remarks>This result creates an <see cref="ODataError"/> with status code: 401.</remarks>
    public class ForbiddenODataResult : ForbidResult, IODataErrorResult
    {
        /// <summary>
        /// OData Error.
        /// </summary>
        public ODataError Error { get; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="message">Error Message</param>
        public ForbiddenODataResult(string message)
        {
            if (message == null)
            {
                ArgumentNullException.ThrowIfNull("message");
            }

            Error = new ODataError
            {
                Message = message,
                ErrorCode = StatusCodes.Status403Forbidden.ToString()
            };
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="odataError">OData Error.</param>
        public ForbiddenODataResult(ODataError odataError)
        {
            Error = odataError;
        }

        /// <inheritdoc/>
        public async override Task ExecuteResultAsync(ActionContext context)
        {
            ObjectResult objectResult = new ObjectResult(Error)
            {
                StatusCode = StatusCodes.Status403Forbidden
            };

            await objectResult.ExecuteResultAsync(context).ConfigureAwait(false);
        }
    }
}
