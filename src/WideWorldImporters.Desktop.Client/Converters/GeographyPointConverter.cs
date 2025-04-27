// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Spatial;
using System.Globalization;
using System.Windows.Data;

namespace WideWorldImporters.Desktop.Client.Converters
{
    public class GeographyPointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is not GeographyPoint point)
            {
                return "-";
            }

            return $"({point.Latitude.ToString(CultureInfo.InvariantCulture)}, {point.Longitude.ToString(CultureInfo.InvariantCulture)})"; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
