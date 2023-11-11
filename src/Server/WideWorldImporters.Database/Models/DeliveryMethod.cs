using System;
using System.Collections.Generic;

namespace WideWorldImporters.Database.Models
{
    public partial class DeliveryMethod
    {
        public DeliveryMethod()
        {
            Customers = new HashSet<Customer>();
            Invoices = new HashSet<Invoice>();
            PurchaseOrders = new HashSet<PurchaseOrder>();
            Suppliers = new HashSet<Supplier>();
        }

        public int DeliveryMethodId { get; set; }
        public string DeliveryMethodName { get; set; } = null!;
        public int LastEditedBy { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
