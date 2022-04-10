using System;
using System.Collections.Generic;

namespace WideWorldImporters.Database.Models
{
    public partial class CustomerTransaction
    {
        public int CustomerTransactionId { get; set; }
        public int CustomerId { get; set; }
        public int TransactionTypeId { get; set; }
        public int? InvoiceId { get; set; }
        public int? PaymentMethodId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal AmountExcludingTax { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal OutstandingBalance { get; set; }
        public DateTime? FinalizationDate { get; set; }
        public bool? IsFinalized { get; set; }
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Invoice? Invoice { get; set; }
        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual PaymentMethod? PaymentMethod { get; set; }
        public virtual TransactionType TransactionType { get; set; } = null!;
    }
}
