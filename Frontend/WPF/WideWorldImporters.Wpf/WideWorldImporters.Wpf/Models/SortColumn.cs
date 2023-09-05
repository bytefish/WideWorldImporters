// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WideWorldImporters.Wpf.Models
{
    public sealed class SortColumn
    {
        public readonly string PropertyName;

        public readonly SortDirection SortDirection;

        public SortColumn(string propertyName, SortDirection sortDirection)
        {
            PropertyName= propertyName;
            SortDirection= sortDirection;
        }
    }
}
