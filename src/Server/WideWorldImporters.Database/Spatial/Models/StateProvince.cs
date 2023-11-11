// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Spatial;
using WideWorldImporters.Database.Spatial;

namespace WideWorldImporters.Database.Models
{
    public partial class StateProvince
    {
        public Geography? EdmBorder
        {
            get
            {
                return GeographyConverter.ConvertTo<Geography>(Border);
            }

            set
            {
                Border = GeographyConverter.ConvertFrom(value);

            }
        }
    }
}
