// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.OData.Routing.Template;
using Microsoft.OData.Edm;
using Microsoft.OpenApi.OData.Edm;

namespace WideWorldImporters.Api.Infrastructure.Swagger
{
    public static class ODataPathTranslater
    {
        public static ODataPath? Translate(this ODataPathTemplate pathTemplate)
        {
            if (pathTemplate.Count == 0)
            {
                // It's service root, so far, let's skip it.
                return null;
            }

            IList<ODataSegment> newSegments = new List<ODataSegment>();
            foreach (var segment in pathTemplate)
            {
                switch (segment)
                {
                    case MetadataSegmentTemplate:
                        newSegments.Add(new ODataMetadataSegment());
                        break;

                    case EntitySetSegmentTemplate entitySet:
                        newSegments.Add(entitySet.ConvertTo());
                        break;

                    case SingletonSegmentTemplate singleton:
                        newSegments.Add(singleton.ConvertTo());
                        break;

                    case KeySegmentTemplate key:
                        newSegments.Add(key.ConvertTo());
                        break;

                    case CastSegmentTemplate cast:
                        newSegments.Add(cast.ConvertTo());
                        break;

                    case PropertySegmentTemplate property:
                        return null;

                    case NavigationSegmentTemplate navigation:
                        newSegments.Add(navigation.ConvertTo());
                        break;

                    case FunctionSegmentTemplate function:
                        newSegments.Add(function.ConvertTo());
                        break;

                    case ActionSegmentTemplate action:
                        newSegments.Add(action.ConvertTo());
                        break;

                    case FunctionImportSegmentTemplate functionImport:
                        newSegments.Add(functionImport.ConvertTo());
                        break;

                    case ActionImportSegmentTemplate actionImport:
                        newSegments.Add(actionImport.ConvertTo());
                        break;
                    case ValueSegmentTemplate value:
                        return null;

                    case NavigationLinkSegmentTemplate navigationLink:
                        return null;

                    case CountSegmentTemplate count:
                        newSegments.Add(count.ConvertTo());
                        break;

                    case PathTemplateSegmentTemplate:
                        return null;

                    case DynamicSegmentTemplate:
                        return null;

                    default:
                        throw new NotSupportedException();
                }
            }

            return new ODataPath(newSegments);
        }

        public static ODataNavigationSourceSegment ConvertTo(this EntitySetSegmentTemplate entitySet)
        {
            return new ODataNavigationSourceSegment(entitySet.Segment.EntitySet);
        }

        public static ODataNavigationSourceSegment ConvertTo(this SingletonSegmentTemplate singleton)
        {
            return new ODataNavigationSourceSegment(singleton.Singleton);
        }

        public static ODataKeySegment ConvertTo(this KeySegmentTemplate key)
        {
            return new ODataKeySegment(key.EntityType, key.KeyMappings);
        }

        public static ODataTypeCastSegment ConvertTo(this CastSegmentTemplate cast)
        {
            // So far, only support the entity type cast
            return new ODataTypeCastSegment(cast.ExpectedType as IEdmEntityType);
        }

        public static ODataNavigationPropertySegment ConvertTo(this NavigationSegmentTemplate navigation)
        {
            return new ODataNavigationPropertySegment(navigation.Segment.NavigationProperty);
        }

        public static ODataOperationSegment ConvertTo(this FunctionSegmentTemplate function)
        {
            return new ODataOperationSegment(function.Function);
        }

        public static ODataOperationSegment ConvertTo(this ActionSegmentTemplate action)
        {
            return new ODataOperationSegment(action.Action);
        }

        public static ODataOperationImportSegment ConvertTo(this FunctionImportSegmentTemplate functionImport)
        {
            return new ODataOperationImportSegment(functionImport.FunctionImport, functionImport.ParameterMappings);
        }

        public static ODataOperationImportSegment ConvertTo(this ActionImportSegmentTemplate actionImport)
        {
            return new ODataOperationImportSegment(actionImport.ActionImport);
        }

        public static ODataDollarCountSegment ConvertTo(this CountSegmentTemplate count)
        {
            return new ODataDollarCountSegment();
        }
    }
}
