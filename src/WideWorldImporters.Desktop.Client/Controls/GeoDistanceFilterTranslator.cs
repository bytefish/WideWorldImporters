// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Spatial;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using System.Reflection;
using System.Xml.Linq;
using WideWorldImportersService;
using WpfDataGridFilter.DynamicLinq.Infrastructure;
using WpfDataGridFilter.Models;

namespace WideWorldImporters.Desktop.Client.Controls
{
    /// <summary>
    /// Used to apply the Geo Distance Queries on an <see cref="IQueryable{T}">.
    /// </summary>
    public class GeoDistanceFilterTranslator : IFilterTranslator
    {
        public FilterType FilterType => GeographyFilter.GeoDistanceFilterType;

        private readonly ParsingConfig _parsingConfig;

        public GeoDistanceFilterTranslator()
        {
            _parsingConfig = GetParsingConfig();

        }

        public IQueryable<TEntity> Convert<TEntity>(IQueryable<TEntity> source, FilterDescriptor filterDescriptor)
        {
            if (filterDescriptor is not GeoDistanceFilterDescriptor f)
            {
                return source;
            }

            // Convert to a Microsoft Spatial Point, we could use in an OData Query
            GeographyPoint point = GeographyPoint.Create(f.Latitude ?? 0, f.Longitude ?? 0);
            
            switch (f.FilterOperator)
            {
                case var _ when f.FilterOperator == GeographyFilter.FilterOperators.DistanceLessThan:
                    return source.Where(_parsingConfig, $"(GeographyOperationsExtensions.Distance({f.PropertyName}, @0) lt @1)", point, f.Distance);
                case var _ when f.FilterOperator == GeographyFilter.FilterOperators.DistanceLessThan:
                    return source.Where(_parsingConfig, $"({f.PropertyName}.Distance{f.PropertyName}, (@0) le @1)", point, f.Distance);
                case var _ when f.FilterOperator == GeographyFilter.FilterOperators.DistanceLessThan:
                    return source.Where(_parsingConfig, $"({f.PropertyName}.Distance({f.PropertyName}, @0) gt @1)", point, f.Distance);
                case var _ when f.FilterOperator == GeographyFilter.FilterOperators.DistanceLessThan:
                    return source.Where(_parsingConfig, $"({f.PropertyName}.Distance({f.PropertyName}, @0) gt @1)", point, f.Distance);
                default:
                    throw new InvalidOperationException($"The Filter Operator '{f.FilterOperator.Name}' is not supported");
            }
        }

        public ParsingConfig GetParsingConfig()
        {
            ParsingConfig parsingConfigWithSpatial = new ParsingConfig();

            parsingConfigWithSpatial.CustomTypeProvider = new DefaultDynamicLinqCustomTypeProvider(parsingConfigWithSpatial, [typeof(GeographyOperationsExtensions)], false);

            return parsingConfigWithSpatial;

        }

    }


}
