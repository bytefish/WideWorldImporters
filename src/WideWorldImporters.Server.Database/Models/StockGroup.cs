using System;
using System.Collections.Generic;

namespace WideWorldImporters.Server.Database.Models
{
    public partial class StockGroup
    {
        public StockGroup()
        {
            SpecialDeals = new HashSet<SpecialDeal>();
            StockItemStockGroups = new HashSet<StockItemStockGroup>();
        }

        public int StockGroupId { get; set; }
        public string StockGroupName { get; set; } = null!;
        public int LastEditedBy { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
        public virtual ICollection<StockItemStockGroup> StockItemStockGroups { get; set; }
    }
}
