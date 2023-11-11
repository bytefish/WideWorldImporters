// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using WideWorldImporters.Client.Blazor.Shared.Models;
using Microsoft.Fast.Components.FluentUI;

namespace WideWorldImporters.Client.Blazor.Infrastructure
{
    /// <summary>
    /// Utility methods for a <see cref="GridItemsProvider{TGridItem}"/>.
    /// </summary>
    public static class DataGridUtils
    {
        /// <summary>
        /// Gets list of <see cref="SortColumn"/> from a given <see cref="GridItemsProvider{TGridItem}"/>.
        /// </summary>
        /// <typeparam name="TGridItem">Type of the GridItem</typeparam>
        /// <param name="request">Request for providing data</param>
        /// <returns>List of <see cref="SortColumn"/></returns>
        public static List<SortColumn> GetSortColumns<TGridItem>(GridItemsProviderRequest<TGridItem> request)
        {
            var sortByProperties = request.GetSortByProperties();

            return Converters.ConvertToSortColumns(sortByProperties);
        }
    }
}
