using System;
using System.Collections.Generic;

namespace WideWorldImporters.Database.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            CustomerTransactions = new HashSet<CustomerTransaction>();
            SupplierTransactions = new HashSet<SupplierTransaction>();
        }

        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; } = null!;
        public int LastEditedBy { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
    }
}
