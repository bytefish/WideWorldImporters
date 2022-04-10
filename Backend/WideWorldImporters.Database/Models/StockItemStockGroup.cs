using System;
using System.Collections.Generic;

namespace WideWorldImporters.Database.Models
{
    public partial class StockItemStockGroup
    {
        public int StockItemStockGroupId { get; set; }
        public int StockItemId { get; set; }
        public int StockGroupId { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual StockGroup StockGroup { get; set; } = null!;
        public virtual StockItem StockItem { get; set; } = null!;
    }
}
