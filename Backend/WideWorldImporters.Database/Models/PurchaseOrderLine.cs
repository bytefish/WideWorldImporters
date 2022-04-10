using System;
using System.Collections.Generic;

namespace WideWorldImporters.Database.Models
{
    public partial class PurchaseOrderLine
    {
        public int PurchaseOrderLineId { get; set; }
        public int PurchaseOrderId { get; set; }
        public int StockItemId { get; set; }
        public int OrderedOuters { get; set; }
        public string Description { get; set; } = null!;
        public int ReceivedOuters { get; set; }
        public int PackageTypeId { get; set; }
        public decimal? ExpectedUnitPricePerOuter { get; set; }
        public DateTime? LastReceiptDate { get; set; }
        public bool IsOrderLineFinalized { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual PackageType PackageType { get; set; } = null!;
        public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
        public virtual StockItem StockItem { get; set; } = null!;
    }
}
