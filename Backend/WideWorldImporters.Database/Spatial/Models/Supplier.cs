// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Spatial;
using WideWorldImporters.Database.Spatial;

namespace WideWorldImporters.Database.Models
{
    public partial class Supplier
    {
        public Geography? EdmDeliveryLocation
        {
            get
            {
                return GeographyConverter.ConvertTo(DeliveryLocation);
            }

            set
            {
                DeliveryLocation = GeographyConverter.ConvertFrom(value);
            }
        }
    }
}
