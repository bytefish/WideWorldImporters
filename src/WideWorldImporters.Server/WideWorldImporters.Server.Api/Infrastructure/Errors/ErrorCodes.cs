namespace WideWorldImporters.Server.Api.Infrastructure.Errors
{
    /// <summary>
    /// Error Codes used in the Application.
    /// </summary>
    public static class ErrorCodes
    {
        /// <summary>
        /// Internal Server Error.
        /// </summary>
        public const string InternalServerError = "System:000001";

        /// <summary>
        /// BadRequest.
        /// </summary>
        public const string BadRequest = "System:000002";

        /// <summary>
        /// Validation Error.
        /// </summary>
        public const string ValidationFailed = "Validation:000001";

        /// <summary>
        /// General Authentication Error.
        /// </summary>
        public const string AuthenticationFailed = "Auth:000001";

        /// <summary>
        /// Entity has not been found.
        /// </summary>
        public const string EntityNotFound = "Entity:000001";

        /// <summary>
        /// Access to Entity has been unauthorized.
        /// </summary>
        public const string EntityUnauthorized = "Entity:000002";

        /// <summary>
        /// Entity has been modified concurrently.
        /// </summary>
        public const string EntityConcurrencyFailure = "Entity:000003";
    }
}
