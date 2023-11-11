using System;
using System.Collections.Generic;

namespace WideWorldImporters.Database.Models
{
    public partial class StockItemHolding
    {
        public int StockItemId { get; set; }
        public int QuantityOnHand { get; set; }
        public string BinLocation { get; set; } = null!;
        public int LastStocktakeQuantity { get; set; }
        public decimal LastCostPrice { get; set; }
        public int ReorderLevel { get; set; }
        public int TargetStockLevel { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual StockItem StockItem { get; set; } = null!;
    }
}
