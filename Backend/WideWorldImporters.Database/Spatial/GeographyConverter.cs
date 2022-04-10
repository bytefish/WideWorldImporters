// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WideWorldImporters.Database.Spatial
{
    public class GeographyConverter
    {
        private static readonly Microsoft.Spatial.WellKnownTextSqlFormatter _wellKnownTextFormatter = Microsoft.Spatial.WellKnownTextSqlFormatter.Create();

        public static Microsoft.Spatial.Geography? ConvertTo(NetTopologySuite.Geometries.Geometry? dbGeometry)
        {
            if(dbGeometry == null)
            {
                return null;
            }

            // Take the simplest possible route and convert to Wkt:
            var wellKnownText = dbGeometry.AsText();

            // Then parse it based on the Source type:
            switch (dbGeometry)
            {
                case NetTopologySuite.Geometries.Point _:
                    return ConvertTo<Microsoft.Spatial.GeographyPoint>(wellKnownText);
                case NetTopologySuite.Geometries.MultiPoint _:
                    return ConvertTo<Microsoft.Spatial.GeographyMultiPoint>(wellKnownText);
                case NetTopologySuite.Geometries.Polygon _:
                    return ConvertTo<Microsoft.Spatial.GeographyPolygon>(wellKnownText);
                case NetTopologySuite.Geometries.MultiPolygon _:
                    return ConvertTo<Microsoft.Spatial.GeographyMultiPolygon>(wellKnownText);
                default:
                    throw new ArgumentException($"Conversion for Type '{dbGeometry.GeometryType}' not supported");
            };
        }

        private static Microsoft.Spatial.Geography ConvertTo<TResult>(string wellKnownText)
            where TResult : Microsoft.Spatial.Geography
        {
            using(var textReader = new StringReader(wellKnownText))
            {
                    return _wellKnownTextFormatter.Read<TResult>(textReader);
            }
        }

        public static NetTopologySuite.Geometries.Geometry? ConvertFrom(Microsoft.Spatial.Geography? geography)
        {
            if(geography == null)
            {
                return null;
            }

            string wellKnownText;

            using (var textWriter = new StringWriter())
            {
                _wellKnownTextFormatter.Write(geography, textWriter);

                wellKnownText = textWriter.ToString();
            }

            return new NetTopologySuite.IO.WKTReader().Read(wellKnownText);
        }
    }
}
