// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Spatial;
using WideWorldImporters.Database.Spatial;

namespace WideWorldImporters.Database.Models
{
    public partial class City
    {
        public GeographyPoint? EdmLocation 
        { 
            get 
            {
                if(Location == null)
                {
                    return default;
                }

                return GeographyConverter.ConvertTo<GeographyPoint>(Location);
            }

            set
            {
                Location = GeographyConverter.ConvertFrom(value);
            }
        }
    }
}
