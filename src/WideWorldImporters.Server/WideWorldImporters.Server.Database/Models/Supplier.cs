using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;
using WideWorldImporters.Server.Database.Models;

namespace WideWorldImporters.Server.Database.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
            StockItems = new HashSet<StockItem>();
            SupplierTransactions = new HashSet<SupplierTransaction>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = null!;
        public int SupplierCategoryId { get; set; }
        public int PrimaryContactPersonId { get; set; }
        public int AlternateContactPersonId { get; set; }
        public int? DeliveryMethodId { get; set; }
        public int DeliveryCityId { get; set; }
        public int PostalCityId { get; set; }
        public string? SupplierReference { get; set; }
        public string? BankAccountName { get; set; }
        public string? BankAccountBranch { get; set; }
        public string? BankAccountCode { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankInternationalCode { get; set; }
        public int PaymentDays { get; set; }
        public string? InternalComments { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string FaxNumber { get; set; } = null!;
        public string WebsiteUrl { get; set; } = null!;
        public string DeliveryAddressLine1 { get; set; } = null!;
        public string? DeliveryAddressLine2 { get; set; }
        public string DeliveryPostalCode { get; set; } = null!;
        public Geometry? DeliveryLocation { get; set; }
        public string PostalAddressLine1 { get; set; } = null!;
        public string? PostalAddressLine2 { get; set; }
        public string PostalPostalCode { get; set; } = null!;
        public int LastEditedBy { get; set; }

        public virtual Person AlternateContactPerson { get; set; } = null!;
        public virtual City DeliveryCity { get; set; } = null!;
        public virtual DeliveryMethod? DeliveryMethod { get; set; }
        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual City PostalCity { get; set; } = null!;
        public virtual Person PrimaryContactPerson { get; set; } = null!;
        public virtual SupplierCategory SupplierCategory { get; set; } = null!;
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
        public virtual ICollection<StockItem> StockItems { get; set; }
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
    }
}
