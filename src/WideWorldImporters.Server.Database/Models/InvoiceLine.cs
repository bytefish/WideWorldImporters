using System;
using System.Collections.Generic;

namespace WideWorldImporters.Server.Database.Models
{
    public partial class InvoiceLine
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int StockItemId { get; set; }
        public string Description { get; set; } = null!;
        public int PackageTypeId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal LineProfit { get; set; }
        public decimal ExtendedPrice { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual Invoice Invoice { get; set; } = null!;
        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual PackageType PackageType { get; set; } = null!;
        public virtual StockItem StockItem { get; set; } = null!;
    }
}
