using System;
using System.Collections.Generic;

namespace WideWorldImporters.Database.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            CustomerTransactions = new HashSet<CustomerTransaction>();
            InvoiceLines = new HashSet<InvoiceLine>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
        }

        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public int BillToCustomerId { get; set; }
        public int? OrderId { get; set; }
        public int DeliveryMethodId { get; set; }
        public int ContactPersonId { get; set; }
        public int AccountsPersonId { get; set; }
        public int SalespersonPersonId { get; set; }
        public int PackedByPersonId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? CustomerPurchaseOrderNumber { get; set; }
        public bool IsCreditNote { get; set; }
        public string? CreditNoteReason { get; set; }
        public string? Comments { get; set; }
        public string? DeliveryInstructions { get; set; }
        public string? InternalComments { get; set; }
        public int TotalDryItems { get; set; }
        public int TotalChillerItems { get; set; }
        public string? DeliveryRun { get; set; }
        public string? RunPosition { get; set; }
        public string? ReturnedDeliveryData { get; set; }
        public DateTime? ConfirmedDeliveryTime { get; set; }
        public string? ConfirmedReceivedBy { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual Person AccountsPerson { get; set; } = null!;
        public virtual Customer BillToCustomer { get; set; } = null!;
        public virtual Person ContactPerson { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual DeliveryMethod DeliveryMethod { get; set; } = null!;
        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual Order? Order { get; set; }
        public virtual Person PackedByPerson { get; set; } = null!;
        public virtual Person SalespersonPerson { get; set; } = null!;
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
    }
}
