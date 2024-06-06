// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService {
    #pragma warning disable CS1591
    public class VehicleTemperature : IAdditionalDataHolder, IParsable 
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The chillerSensorNumber property</summary>
        public int? ChillerSensorNumber { get; set; }
        /// <summary>The compressedSensorData property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public byte[]? CompressedSensorData { get; set; }
#nullable restore
#else
        public byte[] CompressedSensorData { get; set; }
#endif
        /// <summary>The fullSensorData property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? FullSensorData { get; set; }
#nullable restore
#else
        public string FullSensorData { get; set; }
#endif
        /// <summary>The isCompressed property</summary>
        public bool? IsCompressed { get; set; }
        /// <summary>The recordedWhen property</summary>
        public DateTimeOffset? RecordedWhen { get; set; }
        /// <summary>The temperature property</summary>
        public decimal? Temperature { get; set; }
        /// <summary>The vehicleRegistration property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? VehicleRegistration { get; set; }
#nullable restore
#else
        public string VehicleRegistration { get; set; }
#endif
        /// <summary>The vehicleTemperatureId property</summary>
        public long? VehicleTemperatureId { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="VehicleTemperature"/> and sets the default values.
        /// </summary>
        public VehicleTemperature()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="VehicleTemperature"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static VehicleTemperature CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new VehicleTemperature();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"chillerSensorNumber", n => { ChillerSensorNumber = n.GetIntValue(); } },
                {"compressedSensorData", n => { CompressedSensorData = n.GetByteArrayValue(); } },
                {"fullSensorData", n => { FullSensorData = n.GetStringValue(); } },
                {"isCompressed", n => { IsCompressed = n.GetBoolValue(); } },
                {"recordedWhen", n => { RecordedWhen = n.GetDateTimeOffsetValue(); } },
                {"temperature", n => { Temperature = n.GetDecimalValue(); } },
                {"vehicleRegistration", n => { VehicleRegistration = n.GetStringValue(); } },
                {"vehicleTemperatureId", n => { VehicleTemperatureId = n.GetLongValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("chillerSensorNumber", ChillerSensorNumber);
            writer.WriteByteArrayValue("compressedSensorData", CompressedSensorData);
            writer.WriteStringValue("fullSensorData", FullSensorData);
            writer.WriteBoolValue("isCompressed", IsCompressed);
            writer.WriteDateTimeOffsetValue("recordedWhen", RecordedWhen);
            writer.WriteDecimalValue("temperature", Temperature);
            writer.WriteStringValue("vehicleRegistration", VehicleRegistration);
            writer.WriteLongValue("vehicleTemperatureId", VehicleTemperatureId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
