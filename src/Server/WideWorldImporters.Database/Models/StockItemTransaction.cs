using System;
using System.Collections.Generic;

namespace WideWorldImporters.Database.Models
{
    public partial class StockItemTransaction
    {
        public int StockItemTransactionId { get; set; }
        public int StockItemId { get; set; }
        public int TransactionTypeId { get; set; }
        public int? CustomerId { get; set; }
        public int? InvoiceId { get; set; }
        public int? SupplierId { get; set; }
        public int? PurchaseOrderId { get; set; }
        public DateTime TransactionOccurredWhen { get; set; }
        public decimal Quantity { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Invoice? Invoice { get; set; }
        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual PurchaseOrder? PurchaseOrder { get; set; }
        public virtual StockItem StockItem { get; set; } = null!;
        public virtual Supplier? Supplier { get; set; }
        public virtual TransactionType TransactionType { get; set; } = null!;
    }
}
