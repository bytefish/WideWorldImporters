// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.OData.Edm;

namespace WideWorldImporters.Api.Services
{
    /// <summary>
    /// Provides access to an EdmModel.
    /// </summary>
    public interface IEdmService
    {
        /// <summary>
        /// Builds a <see cref="IEdmModel" />.
        /// </summary>
        /// <returns>The <see cref="IEdmModel"/> for the application</returns>
        IEdmModel GetEdmModel();
    }
}
