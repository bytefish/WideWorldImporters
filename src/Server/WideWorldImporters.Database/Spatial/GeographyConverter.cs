// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WideWorldImporters.Database.Spatial
{
    public class GeographyConverter
    {
        private static readonly Microsoft.Spatial.WellKnownTextSqlFormatter _wellKnownTextFormatter = Microsoft.Spatial.WellKnownTextSqlFormatter.Create();

        public static TSpatialType? ConvertTo<TSpatialType>(NetTopologySuite.Geometries.Geometry? dbGeometry)
            where TSpatialType : Microsoft.Spatial.Geography
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
                case NetTopologySuite.Geometries.MultiPoint _:
                case NetTopologySuite.Geometries.Polygon _:
                case NetTopologySuite.Geometries.MultiPolygon _:
                    return ConvertTo(wellKnownText);
                default:
                    throw new ArgumentException($"Conversion for Type '{dbGeometry.GeometryType}' not supported");
            };

            TSpatialType ConvertTo(string wellKnownText)
            {
                using (var textReader = new StringReader(wellKnownText))
                {
                    return _wellKnownTextFormatter.Read<TSpatialType>(textReader);
                }
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
