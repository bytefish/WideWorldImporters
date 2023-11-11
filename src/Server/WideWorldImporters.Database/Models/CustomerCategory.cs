using System;
using System.Collections.Generic;

namespace WideWorldImporters.Database.Models
{
    public partial class CustomerCategory
    {
        public CustomerCategory()
        {
            Customers = new HashSet<Customer>();
            SpecialDeals = new HashSet<SpecialDeal>();
        }

        public int CustomerCategoryId { get; set; }
        public string CustomerCategoryName { get; set; } = null!;
        public int LastEditedBy { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
    }
}
