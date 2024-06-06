// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Kiota.Abstractions.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace WideWorldImporters.Client.Blazor.Extensions
{
    public static class ApiClientExtensions
    {
        /// <summary>
        /// Gets the count metadata or a default value, if the count metadata is not available.
        /// </summary>
        /// <param name="additionalDataHolder">Data Holder for additional properties</param>
        /// <param name="defaultValue">Default Value to return, if count is not available</param>
        /// <returns>Value of the count metadata; else the defaultValue</returns>
        public static int GetODataCount(this IAdditionalDataHolder additionalDataHolder, int defaultValue = 0)
        {
            if (!additionalDataHolder.TryGetODataCount(out var count))
            {
                return defaultValue;
            }

            return count.Value;
        }

        /// <summary>
        /// Tries to get the count from the additional properties, such as the OData metadata.
        /// </summary>
        /// <param name="additionalDataHolder">Data Holder for additional properties</param>
        /// <param name="count">The value of the @odata.count sent by the service</param>
        /// <returns><see cref="true"/>, if @odata.count is available; else <see cref="false"/></returns>
        public static bool TryGetODataCount(this IAdditionalDataHolder additionalDataHolder, [NotNullWhen(true)] out int? count)
        {
            count = null;

            const string key = "@odata.count";

            if (!additionalDataHolder.AdditionalData.TryGetValue(key, out var value))
            {
                count = null;
            }

            if (value == null)
            {
                return false;
            }

            try
            {
                count = Convert.ToInt32(value);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
