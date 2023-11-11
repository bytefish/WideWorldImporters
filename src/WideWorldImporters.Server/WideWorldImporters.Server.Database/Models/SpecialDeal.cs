using System;
using System.Collections.Generic;
using WideWorldImporters.Server.Database.Models;

namespace WideWorldImporters.Server.Database.Models
{
    public partial class SpecialDeal
    {
        public int SpecialDealId { get; set; }
        public int? StockItemId { get; set; }
        public int? CustomerId { get; set; }
        public int? BuyingGroupId { get; set; }
        public int? CustomerCategoryId { get; set; }
        public int? StockGroupId { get; set; }
        public string DealDescription { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? UnitPrice { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual BuyingGroup? BuyingGroup { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual CustomerCategory? CustomerCategory { get; set; }
        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual StockGroup? StockGroup { get; set; }
        public virtual StockItem? StockItem { get; set; }
    }
}
