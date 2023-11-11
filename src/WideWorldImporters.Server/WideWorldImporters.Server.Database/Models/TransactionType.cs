using System;
using System.Collections.Generic;

namespace WideWorldImporters.Server.Database.Models
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            CustomerTransactions = new HashSet<CustomerTransaction>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
            SupplierTransactions = new HashSet<SupplierTransaction>();
        }

        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; } = null!;
        public int LastEditedBy { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
    }
}
