﻿// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Spatial;
using WideWorldImporters.Server.Database.Spatial;

namespace WideWorldImporters.Server.Database.Models
{
    public partial class Customer
    {
        public GeographyPoint? EdmDeliveryLocation
        {
            get
            {
                return GeographyConverter.ConvertTo<GeographyPoint>(DeliveryLocation);
            }

            set
            {
                DeliveryLocation = GeographyConverter.ConvertFrom(value);
            }
        }
    }
}
