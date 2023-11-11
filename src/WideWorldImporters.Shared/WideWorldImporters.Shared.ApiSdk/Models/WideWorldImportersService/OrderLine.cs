// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService {
    public class OrderLine : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The description property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description { get; set; }
#nullable restore
#else
        public string Description { get; set; }
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
        /// <summary>The lastEditedWhen property</summary>
        public DateTimeOffset? LastEditedWhen { get; set; }
        /// <summary>The order property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order? Order { get; set; }
#nullable restore
#else
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order Order { get; set; }
#endif
        /// <summary>The orderId property</summary>
        public int? OrderId { get; set; }
        /// <summary>The orderLineId property</summary>
        public int? OrderLineId { get; set; }
        /// <summary>The packageType property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PackageType? PackageType { get; set; }
#nullable restore
#else
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PackageType PackageType { get; set; }
#endif
        /// <summary>The packageTypeId property</summary>
        public int? PackageTypeId { get; set; }
        /// <summary>The pickedQuantity property</summary>
        public int? PickedQuantity { get; set; }
        /// <summary>The pickingCompletedWhen property</summary>
        public DateTimeOffset? PickingCompletedWhen { get; set; }
        /// <summary>The quantity property</summary>
        public int? Quantity { get; set; }
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
        /// <summary>The taxRate property</summary>
        public decimal? TaxRate { get; set; }
        /// <summary>The unitPrice property</summary>
        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// Instantiates a new OrderLine and sets the default values.
        /// </summary>
        public OrderLine() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static OrderLine CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OrderLine();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"description", n => { Description = n.GetStringValue(); } },
                {"lastEditedBy", n => { LastEditedBy = n.GetIntValue(); } },
                {"lastEditedByNavigation", n => { LastEditedByNavigation = n.GetObjectValue<Person>(Person.CreateFromDiscriminatorValue); } },
                {"lastEditedWhen", n => { LastEditedWhen = n.GetDateTimeOffsetValue(); } },
                {"order", n => { Order = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order.CreateFromDiscriminatorValue); } },
                {"orderId", n => { OrderId = n.GetIntValue(); } },
                {"orderLineId", n => { OrderLineId = n.GetIntValue(); } },
                {"packageType", n => { PackageType = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PackageType>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PackageType.CreateFromDiscriminatorValue); } },
                {"packageTypeId", n => { PackageTypeId = n.GetIntValue(); } },
                {"pickedQuantity", n => { PickedQuantity = n.GetIntValue(); } },
                {"pickingCompletedWhen", n => { PickingCompletedWhen = n.GetDateTimeOffsetValue(); } },
                {"quantity", n => { Quantity = n.GetIntValue(); } },
                {"stockItem", n => { StockItem = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StockItem>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StockItem.CreateFromDiscriminatorValue); } },
                {"stockItemId", n => { StockItemId = n.GetIntValue(); } },
                {"taxRate", n => { TaxRate = n.GetDecimalValue(); } },
                {"unitPrice", n => { UnitPrice = n.GetDecimalValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("description", Description);
            writer.WriteIntValue("lastEditedBy", LastEditedBy);
            writer.WriteObjectValue<Person>("lastEditedByNavigation", LastEditedByNavigation);
            writer.WriteDateTimeOffsetValue("lastEditedWhen", LastEditedWhen);
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order>("order", Order);
            writer.WriteIntValue("orderId", OrderId);
            writer.WriteIntValue("orderLineId", OrderLineId);
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.PackageType>("packageType", PackageType);
            writer.WriteIntValue("packageTypeId", PackageTypeId);
            writer.WriteIntValue("pickedQuantity", PickedQuantity);
            writer.WriteDateTimeOffsetValue("pickingCompletedWhen", PickingCompletedWhen);
            writer.WriteIntValue("quantity", Quantity);
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StockItem>("stockItem", StockItem);
            writer.WriteIntValue("stockItemId", StockItemId);
            writer.WriteDecimalValue("taxRate", TaxRate);
            writer.WriteDecimalValue("unitPrice", UnitPrice);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
