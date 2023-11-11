using System;
using System.Collections.Generic;

namespace WideWorldImporters.Server.Database.Models
{
    public partial class Color
    {
        public Color()
        {
            StockItems = new HashSet<StockItem>();
        }

        public int ColorId { get; set; }
        public string ColorName { get; set; } = null!;
        public int LastEditedBy { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual ICollection<StockItem> StockItems { get; set; }
    }
}
