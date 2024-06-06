// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService {
    #pragma warning disable CS1591
    public class StockItemTransaction : IAdditionalDataHolder, IParsable 
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The customer property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Customer? Customer { get; set; }
#nullable restore
#else
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Customer Customer { get; set; }
#endif
        /// <summary>The customerId property</summary>
        public int? CustomerId { get; set; }
        /// <summary>The invoice property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Invoice? Invoice { get; set; }
#nullable restore
#else
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Invoice Invoice { get; set; }
#endif
        /// <summary>The invoiceId property</summary>
        public int? InvoiceId { get; set; }
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
        /// <summary>The purchaseOrder property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PurchaseOrder? PurchaseOrder { get; set; }
#nullable restore
#else
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PurchaseOrder PurchaseOrder { get; set; }
#endif
        /// <summary>The purchaseOrderId property</summary>
        public int? PurchaseOrderId { get; set; }
        /// <summary>The quantity property</summary>
        public decimal? Quantity { get; set; }
        /// <summary>The stockItem property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StockItem? StockItem { get; set; }
#nullable restore
#else
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StockItem StockItem { get; set; }
#endif
        /// <summary>The stockItemId property</summary>
        public int? StockItemId { get; set; }
        /// <summary>The stockItemTransactionId property</summary>
        public int? StockItemTransactionId { get; set; }
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
        /// <summary>The transactionOccurredWhen property</summary>
        public DateTimeOffset? TransactionOccurredWhen { get; set; }
        /// <summary>The transactionType property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.TransactionType? TransactionType { get; set; }
#nullable restore
#else
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.TransactionType TransactionType { get; set; }
#endif
        /// <summary>The transactionTypeId property</summary>
        public int? TransactionTypeId { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="StockItemTransaction"/> and sets the default values.
        /// </summary>
        public StockItemTransaction()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="StockItemTransaction"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static StockItemTransaction CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new StockItemTransaction();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"customer", n => { Customer = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Customer>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Customer.CreateFromDiscriminatorValue); } },
                {"customerId", n => { CustomerId = n.GetIntValue(); } },
                {"invoice", n => { Invoice = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Invoice>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Invoice.CreateFromDiscriminatorValue); } },
                {"invoiceId", n => { InvoiceId = n.GetIntValue(); } },
                {"lastEditedBy", n => { LastEditedBy = n.GetIntValue(); } },
                {"lastEditedByNavigation", n => { LastEditedByNavigation = n.GetObjectValue<Person>(Person.CreateFromDiscriminatorValue); } },
                {"lastEditedWhen", n => { LastEditedWhen = n.GetDateTimeOffsetValue(); } },
                {"purchaseOrder", n => { PurchaseOrder = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PurchaseOrder>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PurchaseOrder.CreateFromDiscriminatorValue); } },
                {"purchaseOrderId", n => { PurchaseOrderId = n.GetIntValue(); } },
                {"quantity", n => { Quantity = n.GetDecimalValue(); } },
                {"stockItem", n => { StockItem = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StockItem>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StockItem.CreateFromDiscriminatorValue); } },
                {"stockItemId", n => { StockItemId = n.GetIntValue(); } },
                {"stockItemTransactionId", n => { StockItemTransactionId = n.GetIntValue(); } },
                {"supplier", n => { Supplier = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier.CreateFromDiscriminatorValue); } },
                {"supplierId", n => { SupplierId = n.GetIntValue(); } },
                {"transactionOccurredWhen", n => { TransactionOccurredWhen = n.GetDateTimeOffsetValue(); } },
                {"transactionType", n => { TransactionType = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.TransactionType>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.TransactionType.CreateFromDiscriminatorValue); } },
                {"transactionTypeId", n => { TransactionTypeId = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Customer>("customer", Customer);
            writer.WriteIntValue("customerId", CustomerId);
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Invoice>("invoice", Invoice);
            writer.WriteIntValue("invoiceId", InvoiceId);
            writer.WriteIntValue("lastEditedBy", LastEditedBy);
            writer.WriteObjectValue<Person>("lastEditedByNavigation", LastEditedByNavigation);
            writer.WriteDateTimeOffsetValue("lastEditedWhen", LastEditedWhen);
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PurchaseOrder>("purchaseOrder", PurchaseOrder);
            writer.WriteIntValue("purchaseOrderId", PurchaseOrderId);
            writer.WriteDecimalValue("quantity", Quantity);
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StockItem>("stockItem", StockItem);
            writer.WriteIntValue("stockItemId", StockItemId);
            writer.WriteIntValue("stockItemTransactionId", StockItemTransactionId);
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier>("supplier", Supplier);
            writer.WriteIntValue("supplierId", SupplierId);
            writer.WriteDateTimeOffsetValue("transactionOccurredWhen", TransactionOccurredWhen);
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.TransactionType>("transactionType", TransactionType);
            writer.WriteIntValue("transactionTypeId", TransactionTypeId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
