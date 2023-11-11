using System;
using System.Collections.Generic;

namespace WideWorldImporters.Database.Models
{
    public partial class SupplierCategory
    {
        public SupplierCategory()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int SupplierCategoryId { get; set; }
        public string SupplierCategoryName { get; set; } = null!;
        public int LastEditedBy { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
