using System;
using System.Collections.Generic;
using WideWorldImporters.Server.Database.Models;

namespace WideWorldImporters.Server.Database.Models
{
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
            SupplierTransactions = new HashSet<SupplierTransaction>();
        }

        public int PurchaseOrderId { get; set; }
        public int SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public int DeliveryMethodId { get; set; }
        public int ContactPersonId { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string? SupplierReference { get; set; }
        public bool IsOrderFinalized { get; set; }
        public string? Comments { get; set; }
        public string? InternalComments { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }
        public virtual Person ContactPerson { get; set; } = null!;
        public virtual DeliveryMethod DeliveryMethod { get; set; } = null!;
        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual Supplier Supplier { get; set; } = null!;
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
    }
}
