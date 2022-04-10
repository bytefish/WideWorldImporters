using System;
using System.Collections.Generic;

namespace WideWorldImporters.Database.Models
{
    public partial class PackageType
    {
        public PackageType()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
            OrderLines = new HashSet<OrderLine>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            StockItemOuterPackages = new HashSet<StockItem>();
            StockItemUnitPackages = new HashSet<StockItem>();
        }

        public int PackageTypeId { get; set; }
        public string PackageTypeName { get; set; } = null!;
        public int LastEditedBy { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual ICollection<StockItem> StockItemOuterPackages { get; set; }
        public virtual ICollection<StockItem> StockItemUnitPackages { get; set; }
    }
}
