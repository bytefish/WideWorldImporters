// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService {
    #pragma warning disable CS1591
    public class StockItem : IAdditionalDataHolder, IParsable 
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The barcode property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Barcode { get; set; }
#nullable restore
#else
        public string Barcode { get; set; }
#endif
        /// <summary>The brand property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Brand { get; set; }
#nullable restore
#else
        public string Brand { get; set; }
#endif
        /// <summary>The color property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Color? Color { get; set; }
#nullable restore
#else
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Color Color { get; set; }
#endif
        /// <summary>The colorId property</summary>
        public int? ColorId { get; set; }
        /// <summary>The customFields property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CustomFields { get; set; }
#nullable restore
#else
        public string CustomFields { get; set; }
#endif
        /// <summary>The internalComments property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? InternalComments { get; set; }
#nullable restore
#else
        public string InternalComments { get; set; }
#endif
        /// <summary>The invoiceLines property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<InvoiceLine>? InvoiceLines { get; set; }
#nullable restore
#else
        public List<InvoiceLine> InvoiceLines { get; set; }
#endif
        /// <summary>The isChillerStock property</summary>
        public bool? IsChillerStock { get; set; }
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
        /// <summary>The leadTimeDays property</summary>
        public int? LeadTimeDays { get; set; }
        /// <summary>The marketingComments property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? MarketingComments { get; set; }
#nullable restore
#else
        public string MarketingComments { get; set; }
#endif
        /// <summary>The orderLines property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<OrderLine>? OrderLines { get; set; }
#nullable restore
#else
        public List<OrderLine> OrderLines { get; set; }
#endif
        /// <summary>The outerPackage property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public PackageType? OuterPackage { get; set; }
#nullable restore
#else
        public PackageType OuterPackage { get; set; }
#endif
        /// <summary>The outerPackageId property</summary>
        public int? OuterPackageId { get; set; }
        /// <summary>The photo property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public byte[]? Photo { get; set; }
#nullable restore
#else
        public byte[] Photo { get; set; }
#endif
        /// <summary>The purchaseOrderLines property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<PurchaseOrderLine>? PurchaseOrderLines { get; set; }
#nullable restore
#else
        public List<PurchaseOrderLine> PurchaseOrderLines { get; set; }
#endif
        /// <summary>The quantityPerOuter property</summary>
        public int? QuantityPerOuter { get; set; }
        /// <summary>The recommendedRetailPrice property</summary>
        public decimal? RecommendedRetailPrice { get; set; }
        /// <summary>The searchDetails property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SearchDetails { get; set; }
#nullable restore
#else
        public string SearchDetails { get; set; }
#endif
        /// <summary>The size property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Size { get; set; }
#nullable restore
#else
        public string Size { get; set; }
#endif
        /// <summary>The specialDeals property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<SpecialDeal>? SpecialDeals { get; set; }
#nullable restore
#else
        public List<SpecialDeal> SpecialDeals { get; set; }
#endif
        /// <summary>The stockItemHolding property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StockItemHolding? StockItemHolding { get; set; }
#nullable restore
#else
        public WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StockItemHolding StockItemHolding { get; set; }
#endif
        /// <summary>The stockItemId property</summary>
        public int? StockItemId { get; set; }
        /// <summary>The stockItemName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? StockItemName { get; set; }
#nullable restore
#else
        public string StockItemName { get; set; }
#endif
        /// <summary>The stockItemStockGroups property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<StockItemStockGroup>? StockItemStockGroups { get; set; }
#nullable restore
#else
        public List<StockItemStockGroup> StockItemStockGroups { get; set; }
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
        /// <summary>The tags property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Tags { get; set; }
#nullable restore
#else
        public string Tags { get; set; }
#endif
        /// <summary>The taxRate property</summary>
        public decimal? TaxRate { get; set; }
        /// <summary>The typicalWeightPerUnit property</summary>
        public decimal? TypicalWeightPerUnit { get; set; }
        /// <summary>The unitPackage property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public PackageType? UnitPackage { get; set; }
#nullable restore
#else
        public PackageType UnitPackage { get; set; }
#endif
        /// <summary>The unitPackageId property</summary>
        public int? UnitPackageId { get; set; }
        /// <summary>The unitPrice property</summary>
        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="StockItem"/> and sets the default values.
        /// </summary>
        public StockItem()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="StockItem"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static StockItem CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new StockItem();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                {"barcode", n => { Barcode = n.GetStringValue(); } },
                {"brand", n => { Brand = n.GetStringValue(); } },
                {"color", n => { Color = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Color>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Color.CreateFromDiscriminatorValue); } },
                {"colorId", n => { ColorId = n.GetIntValue(); } },
                {"customFields", n => { CustomFields = n.GetStringValue(); } },
                {"internalComments", n => { InternalComments = n.GetStringValue(); } },
                {"invoiceLines", n => { InvoiceLines = n.GetCollectionOfObjectValues<InvoiceLine>(InvoiceLine.CreateFromDiscriminatorValue)?.ToList(); } },
                {"isChillerStock", n => { IsChillerStock = n.GetBoolValue(); } },
                {"lastEditedBy", n => { LastEditedBy = n.GetIntValue(); } },
                {"lastEditedByNavigation", n => { LastEditedByNavigation = n.GetObjectValue<Person>(Person.CreateFromDiscriminatorValue); } },
                {"leadTimeDays", n => { LeadTimeDays = n.GetIntValue(); } },
                {"marketingComments", n => { MarketingComments = n.GetStringValue(); } },
                {"orderLines", n => { OrderLines = n.GetCollectionOfObjectValues<OrderLine>(OrderLine.CreateFromDiscriminatorValue)?.ToList(); } },
                {"outerPackage", n => { OuterPackage = n.GetObjectValue<PackageType>(PackageType.CreateFromDiscriminatorValue); } },
                {"outerPackageId", n => { OuterPackageId = n.GetIntValue(); } },
                {"photo", n => { Photo = n.GetByteArrayValue(); } },
                {"purchaseOrderLines", n => { PurchaseOrderLines = n.GetCollectionOfObjectValues<PurchaseOrderLine>(PurchaseOrderLine.CreateFromDiscriminatorValue)?.ToList(); } },
                {"quantityPerOuter", n => { QuantityPerOuter = n.GetIntValue(); } },
                {"recommendedRetailPrice", n => { RecommendedRetailPrice = n.GetDecimalValue(); } },
                {"searchDetails", n => { SearchDetails = n.GetStringValue(); } },
                {"size", n => { Size = n.GetStringValue(); } },
                {"specialDeals", n => { SpecialDeals = n.GetCollectionOfObjectValues<SpecialDeal>(SpecialDeal.CreateFromDiscriminatorValue)?.ToList(); } },
                {"stockItemHolding", n => { StockItemHolding = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StockItemHolding>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StockItemHolding.CreateFromDiscriminatorValue); } },
                {"stockItemId", n => { StockItemId = n.GetIntValue(); } },
                {"stockItemName", n => { StockItemName = n.GetStringValue(); } },
                {"stockItemStockGroups", n => { StockItemStockGroups = n.GetCollectionOfObjectValues<StockItemStockGroup>(StockItemStockGroup.CreateFromDiscriminatorValue)?.ToList(); } },
                {"stockItemTransactions", n => { StockItemTransactions = n.GetCollectionOfObjectValues<StockItemTransaction>(StockItemTransaction.CreateFromDiscriminatorValue)?.ToList(); } },
                {"supplier", n => { Supplier = n.GetObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier>(WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier.CreateFromDiscriminatorValue); } },
                {"supplierId", n => { SupplierId = n.GetIntValue(); } },
                {"tags", n => { Tags = n.GetStringValue(); } },
                {"taxRate", n => { TaxRate = n.GetDecimalValue(); } },
                {"typicalWeightPerUnit", n => { TypicalWeightPerUnit = n.GetDecimalValue(); } },
                {"unitPackage", n => { UnitPackage = n.GetObjectValue<PackageType>(PackageType.CreateFromDiscriminatorValue); } },
                {"unitPackageId", n => { UnitPackageId = n.GetIntValue(); } },
                {"unitPrice", n => { UnitPrice = n.GetDecimalValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("barcode", Barcode);
            writer.WriteStringValue("brand", Brand);
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Color>("color", Color);
            writer.WriteIntValue("colorId", ColorId);
            writer.WriteStringValue("customFields", CustomFields);
            writer.WriteStringValue("internalComments", InternalComments);
            writer.WriteCollectionOfObjectValues<InvoiceLine>("invoiceLines", InvoiceLines);
            writer.WriteBoolValue("isChillerStock", IsChillerStock);
            writer.WriteIntValue("lastEditedBy", LastEditedBy);
            writer.WriteObjectValue<Person>("lastEditedByNavigation", LastEditedByNavigation);
            writer.WriteIntValue("leadTimeDays", LeadTimeDays);
            writer.WriteStringValue("marketingComments", MarketingComments);
            writer.WriteCollectionOfObjectValues<OrderLine>("orderLines", OrderLines);
            writer.WriteObjectValue<PackageType>("outerPackage", OuterPackage);
            writer.WriteIntValue("outerPackageId", OuterPackageId);
            writer.WriteByteArrayValue("photo", Photo);
            writer.WriteCollectionOfObjectValues<PurchaseOrderLine>("purchaseOrderLines", PurchaseOrderLines);
            writer.WriteIntValue("quantityPerOuter", QuantityPerOuter);
            writer.WriteDecimalValue("recommendedRetailPrice", RecommendedRetailPrice);
            writer.WriteStringValue("searchDetails", SearchDetails);
            writer.WriteStringValue("size", Size);
            writer.WriteCollectionOfObjectValues<SpecialDeal>("specialDeals", SpecialDeals);
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.StockItemHolding>("stockItemHolding", StockItemHolding);
            writer.WriteIntValue("stockItemId", StockItemId);
            writer.WriteStringValue("stockItemName", StockItemName);
            writer.WriteCollectionOfObjectValues<StockItemStockGroup>("stockItemStockGroups", StockItemStockGroups);
            writer.WriteCollectionOfObjectValues<StockItemTransaction>("stockItemTransactions", StockItemTransactions);
            writer.WriteObjectValue<WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService.Supplier>("supplier", Supplier);
            writer.WriteIntValue("supplierId", SupplierId);
            writer.WriteStringValue("tags", Tags);
            writer.WriteDecimalValue("taxRate", TaxRate);
            writer.WriteDecimalValue("typicalWeightPerUnit", TypicalWeightPerUnit);
            writer.WriteObjectValue<PackageType>("unitPackage", UnitPackage);
            writer.WriteIntValue("unitPackageId", UnitPackageId);
            writer.WriteDecimalValue("unitPrice", UnitPrice);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
