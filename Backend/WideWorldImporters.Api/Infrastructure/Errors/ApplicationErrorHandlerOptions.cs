// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WideWorldImporters.Api.Infrastructure.Errors
{
    /// <summary>
    /// Options for the <see cref="DefaultApplicationErrorHandler"/>.
    /// </summary>
    public class ApplicationErrorHandlerOptions
    {
        /// <summary>
        /// Gets or sets the option to include the Exception Details in the response.
        /// </summary>
        public bool IncludeExceptionDetails { get; set; } = false;
    }
}
