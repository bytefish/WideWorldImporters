using System;
using System.Collections.Generic;
using WideWorldImporters.Server.Database.Models;

namespace WideWorldImporters.Server.Database.Models
{
    public partial class Order
    {
        public Order()
        {
            InverseBackorderOrder = new HashSet<Order>();
            Invoices = new HashSet<Invoice>();
            OrderLines = new HashSet<OrderLine>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int SalespersonPersonId { get; set; }
        public int? PickedByPersonId { get; set; }
        public int ContactPersonId { get; set; }
        public int? BackorderOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public string? CustomerPurchaseOrderNumber { get; set; }
        public bool IsUndersupplyBackordered { get; set; }
        public string? Comments { get; set; }
        public string? DeliveryInstructions { get; set; }
        public string? InternalComments { get; set; }
        public DateTime? PickingCompletedWhen { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual Order? BackorderOrder { get; set; }
        public virtual Person ContactPerson { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual Person? PickedByPerson { get; set; }
        public virtual Person SalespersonPerson { get; set; } = null!;
        public virtual ICollection<Order> InverseBackorderOrder { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
