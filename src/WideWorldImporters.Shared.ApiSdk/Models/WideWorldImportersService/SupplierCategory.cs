// <auto-generated/>
#pragma warning disable CS0618
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.0.0")]
    #pragma warning disable CS1591
    public partial class SupplierCategory : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
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
        /// <summary>The supplierCategoryId property</summary>
        public int? SupplierCategoryId { get; set; }
        /// <summary>The supplierCategoryName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SupplierCategoryName { get; set; }
#nullable restore
#else
        public string SupplierCategoryName { get; set; }
#endif
        /// <summary>The suppliers property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier>? Suppliers { get; set; }
#nullable restore
#else
        public List<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier> Suppliers { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.SupplierCategory"/> and sets the default values.
        /// </summary>
        public SupplierCategory()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.SupplierCategory"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.SupplierCategory CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.SupplierCategory();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "lastEditedBy", n => { LastEditedBy = n.GetIntValue(); } },
                { "lastEditedByNavigation", n => { LastEditedByNavigation = n.GetObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person>(global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person.CreateFromDiscriminatorValue); } },
                { "supplierCategoryId", n => { SupplierCategoryId = n.GetIntValue(); } },
                { "supplierCategoryName", n => { SupplierCategoryName = n.GetStringValue(); } },
                { "suppliers", n => { Suppliers = n.GetCollectionOfObjectValues<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier>(global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier.CreateFromDiscriminatorValue)?.AsList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("lastEditedBy", LastEditedBy);
            writer.WriteObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person>("lastEditedByNavigation", LastEditedByNavigation);
            writer.WriteIntValue("supplierCategoryId", SupplierCategoryId);
            writer.WriteStringValue("supplierCategoryName", SupplierCategoryName);
            writer.WriteCollectionOfObjectValues<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier>("suppliers", Suppliers);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
