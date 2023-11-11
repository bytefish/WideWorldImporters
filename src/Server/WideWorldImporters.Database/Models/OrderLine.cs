using System;
using System.Collections.Generic;

namespace WideWorldImporters.Database.Models
{
    public partial class OrderLine
    {
        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public int StockItemId { get; set; }
        public string Description { get; set; } = null!;
        public int PackageTypeId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal TaxRate { get; set; }
        public int PickedQuantity { get; set; }
        public DateTime? PickingCompletedWhen { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
        public virtual PackageType PackageType { get; set; } = null!;
        public virtual StockItem StockItem { get; set; } = null!;
    }
}
