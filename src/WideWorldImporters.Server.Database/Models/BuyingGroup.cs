using System;
using System.Collections.Generic;
using WideWorldImporters.Server.Database.Models;

namespace WideWorldImporters.Server.Database.Models
{
    public partial class BuyingGroup
    {
        public BuyingGroup()
        {
            Customers = new HashSet<Customer>();
            SpecialDeals = new HashSet<SpecialDeal>();
        }

        public int BuyingGroupId { get; set; }
        public string BuyingGroupName { get; set; } = null!;
        public int LastEditedBy { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
    }
}
