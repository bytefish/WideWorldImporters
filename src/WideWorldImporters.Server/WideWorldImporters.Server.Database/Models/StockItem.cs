using System;
using System.Collections.Generic;
using WideWorldImporters.Server.Database.Models;

namespace WideWorldImporters.Server.Database.Models
{
    public partial class StockItem
    {
        public StockItem()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
            OrderLines = new HashSet<OrderLine>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            SpecialDeals = new HashSet<SpecialDeal>();
            StockItemStockGroups = new HashSet<StockItemStockGroup>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
        }

        public int StockItemId { get; set; }
        public string StockItemName { get; set; } = null!;
        public int SupplierId { get; set; }
        public int? ColorId { get; set; }
        public int UnitPackageId { get; set; }
        public int OuterPackageId { get; set; }
        public string? Brand { get; set; }
        public string? Size { get; set; }
        public int LeadTimeDays { get; set; }
        public int QuantityPerOuter { get; set; }
        public bool IsChillerStock { get; set; }
        public string? Barcode { get; set; }
        public decimal TaxRate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? RecommendedRetailPrice { get; set; }
        public decimal TypicalWeightPerUnit { get; set; }
        public string? MarketingComments { get; set; }
        public string? InternalComments { get; set; }
        public byte[]? Photo { get; set; }
        public string? CustomFields { get; set; }
        public string? Tags { get; set; }
        public string SearchDetails { get; set; } = null!;
        public int LastEditedBy { get; set; }

        public virtual Color? Color { get; set; }
        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual PackageType OuterPackage { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
        public virtual PackageType UnitPackage { get; set; } = null!;
        public virtual StockItemHolding StockItemHolding { get; set; } = null!;
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
        public virtual ICollection<StockItemStockGroup> StockItemStockGroups { get; set; }
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
    }
}
