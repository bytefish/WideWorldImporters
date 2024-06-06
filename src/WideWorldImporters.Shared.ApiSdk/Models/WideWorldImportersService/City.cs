// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using WideWorldImporters.Shared.ApiSdk.Models.Edm;
namespace WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService {
    #pragma warning disable CS1591
    public class City : IAdditionalDataHolder, IParsable 
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The cityId property</summary>
        public int? CityId { get; set; }
        /// <summary>The cityName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CityName { get; set; }
#nullable restore
#else
        public string CityName { get; set; }
#endif
        /// <summary>The customerDeliveryCities property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Customer>? CustomerDeliveryCities { get; set; }
#nullable restore
#else
        public List<Customer> CustomerDeliveryCities { get; set; }
#endif
        /// <summary>The customerPostalCities property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Customer>? CustomerPostalCities { get; set; }
#nullable restore
#else
        public List<Customer> CustomerPostalCities { get; set; }
#endif
        /// <summary>The lastEditedBy property</summary>
        public int? LastEditedBy { get; set; }
        /// <summary>The lastEditedByNavigation property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Person? LastEditedByNavigation { get; set; }
#nullable restore
#else
        public Person LastEditedByNavigation { get; set; }
#endif
        /// <summary>The latestRecordedPopulation property</summary>
        public long? LatestRecordedPopulation { get; set; }
        /// <summary>The location property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public GeometryPoint? Location { get; set; }
#nullable restore
#else
        public GeometryPoint Location { get; set; }
#endif
        /// <summary>The stateProvince property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StateProvince? StateProvince { get; set; }
#nullable restore
#else
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StateProvince StateProvince { get; set; }
#endif
        /// <summary>The stateProvinceId property</summary>
        public int? StateProvinceId { get; set; }
        /// <summary>The supplierDeliveryCities property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Supplier>? SupplierDeliveryCities { get; set; }
#nullable restore
#else
        public List<Supplier> SupplierDeliveryCities { get; set; }
#endif
        /// <summary>The supplierPostalCities property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Supplier>? SupplierPostalCities { get; set; }
#nullable restore
#else
        public List<Supplier> SupplierPostalCities { get; set; }
#endif
        /// <summary>The systemParameterDeliveryCities property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<SystemParameter>? SystemParameterDeliveryCities { get; set; }
#nullable restore
#else
        public List<SystemParameter> SystemParameterDeliveryCities { get; set; }
#endif
        /// <summary>The systemParameterPostalCities property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<SystemParameter>? SystemParameterPostalCities { get; set; }
#nullable restore
#else
        public List<SystemParameter> SystemParameterPostalCities { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="City"/> and sets the default values.
        /// </summary>
        public City()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="City"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static City CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new City();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"cityId", n => { CityId = n.GetIntValue(); } },
                {"cityName", n => { CityName = n.GetStringValue(); } },
                {"customerDeliveryCities", n => { CustomerDeliveryCities = n.GetCollectionOfObjectValues<Customer>(Customer.CreateFromDiscriminatorValue)?.ToList(); } },
                {"customerPostalCities", n => { CustomerPostalCities = n.GetCollectionOfObjectValues<Customer>(Customer.CreateFromDiscriminatorValue)?.ToList(); } },
                {"lastEditedBy", n => { LastEditedBy = n.GetIntValue(); } },
                {"lastEditedByNavigation", n => { LastEditedByNavigation = n.GetObjectValue<Person>(Person.CreateFromDiscriminatorValue); } },
                {"latestRecordedPopulation", n => { LatestRecordedPopulation = n.GetLongValue(); } },
                {"location", n => { Location = n.GetObjectValue<GeometryPoint>(GeometryPoint.CreateFromDiscriminatorValue); } },
                {"stateProvince", n => { StateProvince = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StateProvince>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StateProvince.CreateFromDiscriminatorValue); } },
                {"stateProvinceId", n => { StateProvinceId = n.GetIntValue(); } },
                {"supplierDeliveryCities", n => { SupplierDeliveryCities = n.GetCollectionOfObjectValues<Supplier>(Supplier.CreateFromDiscriminatorValue)?.ToList(); } },
                {"supplierPostalCities", n => { SupplierPostalCities = n.GetCollectionOfObjectValues<Supplier>(Supplier.CreateFromDiscriminatorValue)?.ToList(); } },
                {"systemParameterDeliveryCities", n => { SystemParameterDeliveryCities = n.GetCollectionOfObjectValues<SystemParameter>(SystemParameter.CreateFromDiscriminatorValue)?.ToList(); } },
                {"systemParameterPostalCities", n => { SystemParameterPostalCities = n.GetCollectionOfObjectValues<SystemParameter>(SystemParameter.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("cityId", CityId);
            writer.WriteStringValue("cityName", CityName);
            writer.WriteCollectionOfObjectValues<Customer>("customerDeliveryCities", CustomerDeliveryCities);
            writer.WriteCollectionOfObjectValues<Customer>("customerPostalCities", CustomerPostalCities);
            writer.WriteIntValue("lastEditedBy", LastEditedBy);
            writer.WriteObjectValue<Person>("lastEditedByNavigation", LastEditedByNavigation);
            writer.WriteLongValue("latestRecordedPopulation", LatestRecordedPopulation);
            writer.WriteObjectValue<GeometryPoint>("location", Location);
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StateProvince>("stateProvince", StateProvince);
            writer.WriteIntValue("stateProvinceId", StateProvinceId);
            writer.WriteCollectionOfObjectValues<Supplier>("supplierDeliveryCities", SupplierDeliveryCities);
            writer.WriteCollectionOfObjectValues<Supplier>("supplierPostalCities", SupplierPostalCities);
            writer.WriteCollectionOfObjectValues<SystemParameter>("systemParameterDeliveryCities", SystemParameterDeliveryCities);
            writer.WriteCollectionOfObjectValues<SystemParameter>("systemParameterPostalCities", SystemParameterPostalCities);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
