// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace WideWorldImporters.Shared.ApiSdk.Models.Edm {
    #pragma warning disable CS1591
    public class GeometryPoint : IAdditionalDataHolder, IParsable 
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The coordinates property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<double?>? Coordinates { get; set; }
#nullable restore
#else
        public List<double?> Coordinates { get; set; }
#endif
        /// <summary>The type property</summary>
        public GeometryPoint_type? Type { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="GeometryPoint"/> and sets the default values.
        /// </summary>
        public GeometryPoint()
        {
            AdditionalData = new Dictionary<string, object>();
            Type = GeometryPoint_type.Point;
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="GeometryPoint"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static GeometryPoint CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new GeometryPoint();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"coordinates", n => { Coordinates = n.GetCollectionOfPrimitiveValues<double?>()?.ToList(); } },
                {"type", n => { Type = n.GetEnumValue<GeometryPoint_type>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfPrimitiveValues<double?>("coordinates", Coordinates);
            writer.WriteEnumValue<GeometryPoint_type>("type", Type);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
