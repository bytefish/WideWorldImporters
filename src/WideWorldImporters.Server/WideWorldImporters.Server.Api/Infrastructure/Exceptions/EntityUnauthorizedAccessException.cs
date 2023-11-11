// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using WideWorldImporters.Server.Api.Infrastructure.Errors;

namespace WideWorldImporters.Server.Api.Infrastructure.Exceptions
{
    public class EntityUnauthorizedAccessException : ApplicationErrorException
    {
        /// <summary>
        /// Gets or sets an error code.
        /// </summary>
        public override string ErrorCode => ErrorCodes.EntityNotFound;

        /// <summary>
        /// Gets or sets an error code.
        /// </summary>
        public override string ErrorMessage => $"EntityUnauthorizedAccess (User = {UserId}, Entity = {EntityName}, EntityID = {EntityId})";

        /// <summary>
        /// Gets or sets the User ID.
        /// </summary>
        public required int UserId { get; set; }

        /// <summary>
        /// Gets or sets the Entity Name.
        /// </summary>
        public required string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the EntityId.
        /// </summary>
        public required int EntityId { get; set; }

        /// <summary>
        /// Creates a new <see cref="EntityNotFoundException"/>.
        /// </summary>
        /// <param name="message">Error Message</param>
        /// <param name="innerException">Reference to the Inner Exception</param>
        public EntityUnauthorizedAccessException(string? message = null, Exception? innerException = null)
            : base(message, innerException)
        {
        }
    }
}
