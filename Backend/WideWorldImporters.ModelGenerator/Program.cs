using Microsoft.OData.Edm;
using WideWorldImporters.Api.Models;

namespace WideWorldImporters.ModelGenerator // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get the EDM Model used in the WideWorldImporters.Api project ...
            var edmModel = ApplicationEdmModel.GetEdmModel();

            // Create the TypeScript Code Generator with the EntityMetadata list ...
            var typeScriptCodeGenerator = new TypeScriptCodeGen()
            {
                EntityMetadatas = GetEntityMetadata(edmModel)
            };

            // Run the T4 Template to generate the TypeScript code ...
            var typeScriptCode = typeScriptCodeGenerator.TransformText();

            // ... and finall save it to disk:
            File.WriteAllText("entities.codegen.ts", typeScriptCode);
        }

        public static TypeScriptCodeGen.EntityMetadata[] GetEntityMetadata(IEdmModel model)
        {
            var edmEntityTypes = model.SchemaElements
                .OfType<IEdmEntityType>()
                .Cast<EdmEntityType>()
                .ToArray();

            return edmEntityTypes.Select(entity =>
            {
                // Resolve the Metadata for all Declared Properties
                var properties = entity.DeclaredProperties.Select(p => new TypeScriptCodeGen.PropertyMetadata
                {
                    Name = p.Name,
                    Type = GetTypeScriptType(p.Type),
                    IsNullable = p.Type.IsNullable,
                    IsEntity = p.Type.IsEntity(),
                    IsCollection = p.Type.IsCollection(),
                    ElementType = p.Type.IsCollection() ? GetTypeScriptType(p.Type.AsCollection().ElementType()) : null,
                    ElementIsNullable = p.Type.IsCollection() ? p.Type.AsCollection().ElementType().IsNullable : null,
                }).ToArray();

                return new TypeScriptCodeGen.EntityMetadata
                {
                    Name = entity.Name,
                    Properties = properties
                };
            }).ToArray();
        }

        private static string GetTypeScriptType(IEdmTypeReference edmTypeReference)
        {
            if (edmTypeReference.IsCollection())
            {
                return "[]";
            }
            else if (edmTypeReference.IsEntity())
            {
                return edmTypeReference.FullName().Split(".").Last();
            }
            else if (edmTypeReference.IsBinary() || edmTypeReference.IsSpatial() || edmTypeReference.IsGeometry() || edmTypeReference.IsGeography())
            {
                return "any";
            }
            else if (edmTypeReference.IsPrimitive())
            {
                return GetByPrimitiveType(edmTypeReference.AsPrimitive());
            }

            return string.Empty;
        }

        private static string GetByPrimitiveType(IEdmPrimitiveTypeReference edmPrimitiveTypeReference)
        {
            var edmPrimitiveKind = edmPrimitiveTypeReference.PrimitiveKind();

            switch (edmPrimitiveKind)
            {
                case EdmPrimitiveTypeKind.Binary:
                    return "string";
                case EdmPrimitiveTypeKind.Boolean:
                    return "boolean";
                case EdmPrimitiveTypeKind.SByte:
                case EdmPrimitiveTypeKind.Byte:
                case EdmPrimitiveTypeKind.Int16:
                case EdmPrimitiveTypeKind.Int32:
                case EdmPrimitiveTypeKind.Int64:
                case EdmPrimitiveTypeKind.Single:
                case EdmPrimitiveTypeKind.Double:
                case EdmPrimitiveTypeKind.Decimal:
                    return "number";
                case EdmPrimitiveTypeKind.String:
                    return "string";
                case EdmPrimitiveTypeKind.Date:
                case EdmPrimitiveTypeKind.DateTimeOffset:
                    return "Date";
                case EdmPrimitiveTypeKind.Guid:
                    return "string";
                case EdmPrimitiveTypeKind.Geography:
                case EdmPrimitiveTypeKind.GeographyCollection:
                case EdmPrimitiveTypeKind.GeographyPolygon:
                case EdmPrimitiveTypeKind.GeographyPoint:
                case EdmPrimitiveTypeKind.GeographyMultiPoint:
                case EdmPrimitiveTypeKind.GeographyLineString:
                case EdmPrimitiveTypeKind.GeographyMultiLineString:
                    return "string";
                default:
                    return "any";
            }
        }
    }
}