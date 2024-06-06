// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using WideWorldImporters.Server.Api.Infrastructure.Errors;

namespace WideWorldImporters.Server.Api.Infrastructure.Exceptions
{
    public class AuthenticationFailedException : ApplicationErrorException
    {
        /// <summary>
        /// Gets or sets an ErrorCode.
        /// </summary>
        public override string ErrorCode => ErrorCodes.AuthenticationFailed;

        /// <summary>
        /// Gets or sets an ErrorMessage.
        /// </summary>
        public override string ErrorMessage => $"AuthenticationFailed";

        /// <summary>
        /// Creates a new <see cref="EntityNotFoundException"/>.
        /// </summary>
        /// <param name="message">Error Message</param>
        /// <param name="innerException">Reference to the Inner Exception</param>
        public AuthenticationFailedException(string? message = null, Exception? innerException = null)
            : base(message, innerException)
        {
        }
    }
}
