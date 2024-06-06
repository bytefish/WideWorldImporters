// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService {
    #pragma warning disable CS1591
    public class PurchaseOrder : IAdditionalDataHolder, IParsable 
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The comments property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Comments { get; set; }
#nullable restore
#else
        public string Comments { get; set; }
#endif
        /// <summary>The contactPerson property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Person? ContactPerson { get; set; }
#nullable restore
#else
        public Person ContactPerson { get; set; }
#endif
        /// <summary>The contactPersonId property</summary>
        public int? ContactPersonId { get; set; }
        /// <summary>The deliveryMethod property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.DeliveryMethod? DeliveryMethod { get; set; }
#nullable restore
#else
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.DeliveryMethod DeliveryMethod { get; set; }
#endif
        /// <summary>The deliveryMethodId property</summary>
        public int? DeliveryMethodId { get; set; }
        /// <summary>The expectedDeliveryDate property</summary>
        public DateTimeOffset? ExpectedDeliveryDate { get; set; }
        /// <summary>The internalComments property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? InternalComments { get; set; }
#nullable restore
#else
        public string InternalComments { get; set; }
#endif
        /// <summary>The isOrderFinalized property</summary>
        public bool? IsOrderFinalized { get; set; }
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
        /// <summary>The lastEditedWhen property</summary>
        public DateTimeOffset? LastEditedWhen { get; set; }
        /// <summary>The orderDate property</summary>
        public DateTimeOffset? OrderDate { get; set; }
        /// <summary>The purchaseOrderId property</summary>
        public int? PurchaseOrderId { get; set; }
        /// <summary>The purchaseOrderLines property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<PurchaseOrderLine>? PurchaseOrderLines { get; set; }
#nullable restore
#else
        public List<PurchaseOrderLine> PurchaseOrderLines { get; set; }
#endif
        /// <summary>The stockItemTransactions property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<StockItemTransaction>? StockItemTransactions { get; set; }
#nullable restore
#else
        public List<StockItemTransaction> StockItemTransactions { get; set; }
#endif
        /// <summary>The supplier property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier? Supplier { get; set; }
#nullable restore
#else
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier Supplier { get; set; }
#endif
        /// <summary>The supplierId property</summary>
        public int? SupplierId { get; set; }
        /// <summary>The supplierReference property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SupplierReference { get; set; }
#nullable restore
#else
        public string SupplierReference { get; set; }
#endif
        /// <summary>The supplierTransactions property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<SupplierTransaction>? SupplierTransactions { get; set; }
#nullable restore
#else
        public List<SupplierTransaction> SupplierTransactions { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="PurchaseOrder"/> and sets the default values.
        /// </summary>
        public PurchaseOrder()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="PurchaseOrder"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static PurchaseOrder CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new PurchaseOrder();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"comments", n => { Comments = n.GetStringValue(); } },
                {"contactPerson", n => { ContactPerson = n.GetObjectValue<Person>(Person.CreateFromDiscriminatorValue); } },
                {"contactPersonId", n => { ContactPersonId = n.GetIntValue(); } },
                {"deliveryMethod", n => { DeliveryMethod = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.DeliveryMethod>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.DeliveryMethod.CreateFromDiscriminatorValue); } },
                {"deliveryMethodId", n => { DeliveryMethodId = n.GetIntValue(); } },
                {"expectedDeliveryDate", n => { ExpectedDeliveryDate = n.GetDateTimeOffsetValue(); } },
                {"internalComments", n => { InternalComments = n.GetStringValue(); } },
                {"isOrderFinalized", n => { IsOrderFinalized = n.GetBoolValue(); } },
                {"lastEditedBy", n => { LastEditedBy = n.GetIntValue(); } },
                {"lastEditedByNavigation", n => { LastEditedByNavigation = n.GetObjectValue<Person>(Person.CreateFromDiscriminatorValue); } },
                {"lastEditedWhen", n => { LastEditedWhen = n.GetDateTimeOffsetValue(); } },
                {"orderDate", n => { OrderDate = n.GetDateTimeOffsetValue(); } },
                {"purchaseOrderId", n => { PurchaseOrderId = n.GetIntValue(); } },
                {"purchaseOrderLines", n => { PurchaseOrderLines = n.GetCollectionOfObjectValues<PurchaseOrderLine>(PurchaseOrderLine.CreateFromDiscriminatorValue)?.ToList(); } },
                {"stockItemTransactions", n => { StockItemTransactions = n.GetCollectionOfObjectValues<StockItemTransaction>(StockItemTransaction.CreateFromDiscriminatorValue)?.ToList(); } },
                {"supplier", n => { Supplier = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier.CreateFromDiscriminatorValue); } },
                {"supplierId", n => { SupplierId = n.GetIntValue(); } },
                {"supplierReference", n => { SupplierReference = n.GetStringValue(); } },
                {"supplierTransactions", n => { SupplierTransactions = n.GetCollectionOfObjectValues<SupplierTransaction>(SupplierTransaction.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("comments", Comments);
            writer.WriteObjectValue<Person>("contactPerson", ContactPerson);
            writer.WriteIntValue("contactPersonId", ContactPersonId);
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.DeliveryMethod>("deliveryMethod", DeliveryMethod);
            writer.WriteIntValue("deliveryMethodId", DeliveryMethodId);
            writer.WriteDateTimeOffsetValue("expectedDeliveryDate", ExpectedDeliveryDate);
            writer.WriteStringValue("internalComments", InternalComments);
            writer.WriteBoolValue("isOrderFinalized", IsOrderFinalized);
            writer.WriteIntValue("lastEditedBy", LastEditedBy);
            writer.WriteObjectValue<Person>("lastEditedByNavigation", LastEditedByNavigation);
            writer.WriteDateTimeOffsetValue("lastEditedWhen", LastEditedWhen);
            writer.WriteDateTimeOffsetValue("orderDate", OrderDate);
            writer.WriteIntValue("purchaseOrderId", PurchaseOrderId);
            writer.WriteCollectionOfObjectValues<PurchaseOrderLine>("purchaseOrderLines", PurchaseOrderLines);
            writer.WriteCollectionOfObjectValues<StockItemTransaction>("stockItemTransactions", StockItemTransactions);
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier>("supplier", Supplier);
            writer.WriteIntValue("supplierId", SupplierId);
            writer.WriteStringValue("supplierReference", SupplierReference);
            writer.WriteCollectionOfObjectValues<SupplierTransaction>("supplierTransactions", SupplierTransactions);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
