// Licensed under the MIT license. See LICENSE file in the project root for full license information.


using Microsoft.Spatial;
using System.ComponentModel.DataAnnotations.Schema;
using WideWorldImporters.Database.Spatial;

namespace WideWorldImporters.Database.Models
{
    public partial class Country
    {
        public Geography? EdmBorder
        {
            get
            {
                return GeographyConverter.ConvertTo(Border);
            }

            set
            {
                Border = GeographyConverter.ConvertFrom(value);

            }
        }
    }
}
