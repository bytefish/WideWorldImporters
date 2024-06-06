using Microsoft.AspNetCore.OData.Query.Expressions;
using Microsoft.OData.UriParser;
using Microsoft.Spatial;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System.Linq.Expressions;
using System.Reflection;

namespace WideWorldImporters.Server.Api.Infrastructure.Spatial
{
    public class GeoDistanceFilterBinder : FilterBinder
    {
        internal const string GeoDistanceFunctionName = "geo.distance";

        private static readonly MethodInfo distanceMethodDb = typeof(NetTopologySuite.Geometries.Geometry).GetMethod("Distance")!;

        public override Expression BindSingleValueFunctionCallNode(SingleValueFunctionCallNode node, QueryBinderContext context)
        {
            switch (node.Name)
            {
                case GeoDistanceFunctionName:
                    return BindGeoDistance(node, context);
                default:
                    return base.BindSingleValueFunctionCallNode(node, context);
            }
        }

        public Expression BindGeoDistance(SingleValueFunctionCallNode node, QueryBinderContext context)
        {
            var bindGeoDistanceExpression = InternalBindGeoDistance(node, context);

            if (bindGeoDistanceExpression == null)
            {
                throw new InvalidOperationException($"FilterBinder failed to bind FunctionName {GeoDistanceFunctionName}");
            }

            return bindGeoDistanceExpression;
        }

        public Expression? InternalBindGeoDistance(SingleValueFunctionCallNode node, QueryBinderContext context)
        {
            Expression[] arguments = BindArguments(node.Parameters, context);

            string? propertyName = null;

            foreach (var queryNode in node.Parameters)
            {
                if (queryNode != null && queryNode is SingleValuePropertyAccessNode)
                {
                    SingleValuePropertyAccessNode svpan = (SingleValuePropertyAccessNode)queryNode;

                    propertyName = svpan.Property.Name;
                }
            }

            Expression? expression = null;

            if (propertyName != null)
            {
                GetPointExpressions(arguments, propertyName, out MemberExpression? memberExpression, out ConstantExpression? constantExpression);

                if (memberExpression != null && constantExpression != null)
                {
                    expression = Expression.Call(memberExpression, distanceMethodDb, constantExpression);
                }

            }

            return expression;
        }

        private static void GetPointExpressions(Expression[] expressions, string propertyName, out MemberExpression? memberExpression, out ConstantExpression? constantExpression)
        {
            memberExpression = null;
            constantExpression = null;

            foreach (Expression expression in expressions)
            {
                var memberExpr = expression as MemberExpression;

                if (memberExpr == null)
                {
                    continue;
                }

                var constantExpr = memberExpr!.Expression as ConstantExpression;

                if (constantExpr != null)
                {
                    GeographyPoint? point = GetGeographyPointFromConstantExpression(constantExpr);

                    if (point != null)
                    {
                        constantExpression = Expression.Constant(CreatePoint(point.Latitude, point.Longitude));
                    }
                }
                else
                {
                    if (memberExpr.Expression != null)
                    {
                        memberExpression = Expression.Property(memberExpr.Expression, propertyName);
                    }
                }
            }
        }

        private static GeographyPoint? GetGeographyPointFromConstantExpression(ConstantExpression expression)
        {
            GeographyPoint? point = default;

            if (expression != null)
            {
                PropertyInfo? constantExpressionValuePropertyInfo = expression.Type.GetProperty("Property");

                if (constantExpressionValuePropertyInfo != null)
                {
                    point = constantExpressionValuePropertyInfo.GetValue(expression.Value) as GeographyPoint;
                }
            }

            return point;
        }

        private static Point CreatePoint(double latitude, double longitude)
        {
            // 4326 is most common coordinate system used by GPS/Maps
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            // see https://docs.microsoft.com/en-us/ef/core/modeling/spatial
            // Longitude and Latitude
            var newLocation = geometryFactory.CreatePoint(new Coordinate(longitude, latitude));

            return newLocation;
        }
    }
}
