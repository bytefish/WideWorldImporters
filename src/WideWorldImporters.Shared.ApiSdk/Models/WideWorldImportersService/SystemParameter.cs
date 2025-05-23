// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
using WideWorldImporters.Shared.ApiSdk.Models.Edm;
namespace WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class SystemParameter : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The applicationSettings property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ApplicationSettings { get; set; }
#nullable restore
#else
        public string ApplicationSettings { get; set; }
#endif
        /// <summary>The deliveryAddressLine1 property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DeliveryAddressLine1 { get; set; }
#nullable restore
#else
        public string DeliveryAddressLine1 { get; set; }
#endif
        /// <summary>The deliveryAddressLine2 property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DeliveryAddressLine2 { get; set; }
#nullable restore
#else
        public string DeliveryAddressLine2 { get; set; }
#endif
        /// <summary>The deliveryCity property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.City? DeliveryCity { get; set; }
#nullable restore
#else
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.City DeliveryCity { get; set; }
#endif
        /// <summary>The deliveryCityId property</summary>
        public int? DeliveryCityId { get; set; }
        /// <summary>The deliveryLocation property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::WideWorldImporters.Shared.ApiSdk.Models.Edm.GeographyPoint? DeliveryLocation { get; set; }
#nullable restore
#else
        public global::WideWorldImporters.Shared.ApiSdk.Models.Edm.GeographyPoint DeliveryLocation { get; set; }
#endif
        /// <summary>The deliveryPostalCode property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DeliveryPostalCode { get; set; }
#nullable restore
#else
        public string DeliveryPostalCode { get; set; }
#endif
        /// <summary>The lastEditedBy property</summary>
        public int? LastEditedBy { get; set; }
        /// <summary>The lastEditedByNavigation property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person? LastEditedByNavigation { get; set; }
#nullable restore
#else
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person LastEditedByNavigation { get; set; }
#endif
        /// <summary>The lastEditedWhen property</summary>
        public DateTimeOffset? LastEditedWhen { get; set; }
        /// <summary>The postalAddressLine1 property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PostalAddressLine1 { get; set; }
#nullable restore
#else
        public string PostalAddressLine1 { get; set; }
#endif
        /// <summary>The postalAddressLine2 property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PostalAddressLine2 { get; set; }
#nullable restore
#else
        public string PostalAddressLine2 { get; set; }
#endif
        /// <summary>The postalCity property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.City? PostalCity { get; set; }
#nullable restore
#else
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.City PostalCity { get; set; }
#endif
        /// <summary>The postalCityId property</summary>
        public int? PostalCityId { get; set; }
        /// <summary>The postalPostalCode property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PostalPostalCode { get; set; }
#nullable restore
#else
        public string PostalPostalCode { get; set; }
#endif
        /// <summary>The systemParameterId property</summary>
        public int? SystemParameterId { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.SystemParameter"/> and sets the default values.
        /// </summary>
        public SystemParameter()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.SystemParameter"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.SystemParameter CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.SystemParameter();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "applicationSettings", n => { ApplicationSettings = n.GetStringValue(); } },
                { "deliveryAddressLine1", n => { DeliveryAddressLine1 = n.GetStringValue(); } },
                { "deliveryAddressLine2", n => { DeliveryAddressLine2 = n.GetStringValue(); } },
                { "deliveryCity", n => { DeliveryCity = n.GetObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.City>(global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.City.CreateFromDiscriminatorValue); } },
                { "deliveryCityId", n => { DeliveryCityId = n.GetIntValue(); } },
                { "deliveryLocation", n => { DeliveryLocation = n.GetObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.Edm.GeographyPoint>(global::WideWorldImporters.Shared.ApiSdk.Models.Edm.GeographyPoint.CreateFromDiscriminatorValue); } },
                { "deliveryPostalCode", n => { DeliveryPostalCode = n.GetStringValue(); } },
                { "lastEditedBy", n => { LastEditedBy = n.GetIntValue(); } },
                { "lastEditedByNavigation", n => { LastEditedByNavigation = n.GetObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person>(global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person.CreateFromDiscriminatorValue); } },
                { "lastEditedWhen", n => { LastEditedWhen = n.GetDateTimeOffsetValue(); } },
                { "postalAddressLine1", n => { PostalAddressLine1 = n.GetStringValue(); } },
                { "postalAddressLine2", n => { PostalAddressLine2 = n.GetStringValue(); } },
                { "postalCity", n => { PostalCity = n.GetObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.City>(global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.City.CreateFromDiscriminatorValue); } },
                { "postalCityId", n => { PostalCityId = n.GetIntValue(); } },
                { "postalPostalCode", n => { PostalPostalCode = n.GetStringValue(); } },
                { "systemParameterId", n => { SystemParameterId = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("applicationSettings", ApplicationSettings);
            writer.WriteStringValue("deliveryAddressLine1", DeliveryAddressLine1);
            writer.WriteStringValue("deliveryAddressLine2", DeliveryAddressLine2);
            writer.WriteObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.City>("deliveryCity", DeliveryCity);
            writer.WriteIntValue("deliveryCityId", DeliveryCityId);
            writer.WriteObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.Edm.GeographyPoint>("deliveryLocation", DeliveryLocation);
            writer.WriteStringValue("deliveryPostalCode", DeliveryPostalCode);
            writer.WriteIntValue("lastEditedBy", LastEditedBy);
            writer.WriteObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person>("lastEditedByNavigation", LastEditedByNavigation);
            writer.WriteDateTimeOffsetValue("lastEditedWhen", LastEditedWhen);
            writer.WriteStringValue("postalAddressLine1", PostalAddressLine1);
            writer.WriteStringValue("postalAddressLine2", PostalAddressLine2);
            writer.WriteObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.City>("postalCity", PostalCity);
            writer.WriteIntValue("postalCityId", PostalCityId);
            writer.WriteStringValue("postalPostalCode", PostalPostalCode);
            writer.WriteIntValue("systemParameterId", SystemParameterId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
