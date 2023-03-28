using Microsoft.OData.Edm;
using System;
using System.Text;
using WideWorldImporters.Api.Models;
using WideWorldImporters.Database.Models;

namespace WideWorldImporters.ModelGenerator // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var model = ApplicationEdmModel.GetEdmModel();

            //Evaluate(model);
            var typescriptCode = new TypeScriptCodeGen
            {
                EntityMetadatas = GetEntityMetadata(model)
            }.TransformText();

            File.WriteAllText("entities.codegen.ts", typescriptCode);
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