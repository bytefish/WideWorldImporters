// Licensed under the MIT license. See LICENSE file in the project root for full license information.


using Microsoft.Spatial;
using WideWorldImporters.Server.Database.Spatial;

namespace WideWorldImporters.Server.Database.Models
{
    public partial class Country
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
