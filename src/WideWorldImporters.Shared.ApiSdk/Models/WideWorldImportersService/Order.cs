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
    public partial class Order : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The backorderOrder property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order? BackorderOrder { get; set; }
#nullable restore
#else
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order BackorderOrder { get; set; }
#endif
        /// <summary>The backorderOrderId property</summary>
        public int? BackorderOrderId { get; set; }
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
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person? ContactPerson { get; set; }
#nullable restore
#else
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person ContactPerson { get; set; }
#endif
        /// <summary>The contactPersonId property</summary>
        public int? ContactPersonId { get; set; }
        /// <summary>The customer property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Customer? Customer { get; set; }
#nullable restore
#else
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Customer Customer { get; set; }
#endif
        /// <summary>The customerId property</summary>
        public int? CustomerId { get; set; }
        /// <summary>The customerPurchaseOrderNumber property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CustomerPurchaseOrderNumber { get; set; }
#nullable restore
#else
        public string CustomerPurchaseOrderNumber { get; set; }
#endif
        /// <summary>The deliveryInstructions property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DeliveryInstructions { get; set; }
#nullable restore
#else
        public string DeliveryInstructions { get; set; }
#endif
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
        /// <summary>The inverseBackorderOrder property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order>? InverseBackorderOrder { get; set; }
#nullable restore
#else
        public List<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order> InverseBackorderOrder { get; set; }
#endif
        /// <summary>The invoices property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Invoice>? Invoices { get; set; }
#nullable restore
#else
        public List<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Invoice> Invoices { get; set; }
#endif
        /// <summary>The isUndersupplyBackordered property</summary>
        public bool? IsUndersupplyBackordered { get; set; }
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
        /// <summary>The orderDate property</summary>
        public DateTimeOffset? OrderDate { get; set; }
        /// <summary>The orderId property</summary>
        public int? OrderId { get; set; }
        /// <summary>The orderLines property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.OrderLine>? OrderLines { get; set; }
#nullable restore
#else
        public List<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.OrderLine> OrderLines { get; set; }
#endif
        /// <summary>The pickedByPerson property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person? PickedByPerson { get; set; }
#nullable restore
#else
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person PickedByPerson { get; set; }
#endif
        /// <summary>The pickedByPersonId property</summary>
        public int? PickedByPersonId { get; set; }
        /// <summary>The pickingCompletedWhen property</summary>
        public DateTimeOffset? PickingCompletedWhen { get; set; }
        /// <summary>The salespersonPerson property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person? SalespersonPerson { get; set; }
#nullable restore
#else
        public global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person SalespersonPerson { get; set; }
#endif
        /// <summary>The salespersonPersonId property</summary>
        public int? SalespersonPersonId { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order"/> and sets the default values.
        /// </summary>
        public Order()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "backorderOrder", n => { BackorderOrder = n.GetObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order>(global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order.CreateFromDiscriminatorValue); } },
                { "backorderOrderId", n => { BackorderOrderId = n.GetIntValue(); } },
                { "comments", n => { Comments = n.GetStringValue(); } },
                { "contactPerson", n => { ContactPerson = n.GetObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person>(global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person.CreateFromDiscriminatorValue); } },
                { "contactPersonId", n => { ContactPersonId = n.GetIntValue(); } },
                { "customer", n => { Customer = n.GetObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Customer>(global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Customer.CreateFromDiscriminatorValue); } },
                { "customerId", n => { CustomerId = n.GetIntValue(); } },
                { "customerPurchaseOrderNumber", n => { CustomerPurchaseOrderNumber = n.GetStringValue(); } },
                { "deliveryInstructions", n => { DeliveryInstructions = n.GetStringValue(); } },
                { "expectedDeliveryDate", n => { ExpectedDeliveryDate = n.GetDateTimeOffsetValue(); } },
                { "internalComments", n => { InternalComments = n.GetStringValue(); } },
                { "inverseBackorderOrder", n => { InverseBackorderOrder = n.GetCollectionOfObjectValues<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order>(global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order.CreateFromDiscriminatorValue)?.AsList(); } },
                { "invoices", n => { Invoices = n.GetCollectionOfObjectValues<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Invoice>(global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Invoice.CreateFromDiscriminatorValue)?.AsList(); } },
                { "isUndersupplyBackordered", n => { IsUndersupplyBackordered = n.GetBoolValue(); } },
                { "lastEditedBy", n => { LastEditedBy = n.GetIntValue(); } },
                { "lastEditedByNavigation", n => { LastEditedByNavigation = n.GetObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person>(global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person.CreateFromDiscriminatorValue); } },
                { "lastEditedWhen", n => { LastEditedWhen = n.GetDateTimeOffsetValue(); } },
                { "orderDate", n => { OrderDate = n.GetDateTimeOffsetValue(); } },
                { "orderId", n => { OrderId = n.GetIntValue(); } },
                { "orderLines", n => { OrderLines = n.GetCollectionOfObjectValues<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.OrderLine>(global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.OrderLine.CreateFromDiscriminatorValue)?.AsList(); } },
                { "pickedByPerson", n => { PickedByPerson = n.GetObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person>(global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person.CreateFromDiscriminatorValue); } },
                { "pickedByPersonId", n => { PickedByPersonId = n.GetIntValue(); } },
                { "pickingCompletedWhen", n => { PickingCompletedWhen = n.GetDateTimeOffsetValue(); } },
                { "salespersonPerson", n => { SalespersonPerson = n.GetObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person>(global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person.CreateFromDiscriminatorValue); } },
                { "salespersonPersonId", n => { SalespersonPersonId = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order>("backorderOrder", BackorderOrder);
            writer.WriteIntValue("backorderOrderId", BackorderOrderId);
            writer.WriteStringValue("comments", Comments);
            writer.WriteObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person>("contactPerson", ContactPerson);
            writer.WriteIntValue("contactPersonId", ContactPersonId);
            writer.WriteObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Customer>("customer", Customer);
            writer.WriteIntValue("customerId", CustomerId);
            writer.WriteStringValue("customerPurchaseOrderNumber", CustomerPurchaseOrderNumber);
            writer.WriteStringValue("deliveryInstructions", DeliveryInstructions);
            writer.WriteDateTimeOffsetValue("expectedDeliveryDate", ExpectedDeliveryDate);
            writer.WriteStringValue("internalComments", InternalComments);
            writer.WriteCollectionOfObjectValues<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Order>("inverseBackorderOrder", InverseBackorderOrder);
            writer.WriteCollectionOfObjectValues<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Invoice>("invoices", Invoices);
            writer.WriteBoolValue("isUndersupplyBackordered", IsUndersupplyBackordered);
            writer.WriteIntValue("lastEditedBy", LastEditedBy);
            writer.WriteObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person>("lastEditedByNavigation", LastEditedByNavigation);
            writer.WriteDateTimeOffsetValue("lastEditedWhen", LastEditedWhen);
            writer.WriteDateTimeOffsetValue("orderDate", OrderDate);
            writer.WriteIntValue("orderId", OrderId);
            writer.WriteCollectionOfObjectValues<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.OrderLine>("orderLines", OrderLines);
            writer.WriteObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person>("pickedByPerson", PickedByPerson);
            writer.WriteIntValue("pickedByPersonId", PickedByPersonId);
            writer.WriteDateTimeOffsetValue("pickingCompletedWhen", PickingCompletedWhen);
            writer.WriteObjectValue<global::WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Person>("salespersonPerson", SalespersonPerson);
            writer.WriteIntValue("salespersonPersonId", SalespersonPersonId);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
#pragma warning restore CS0618
