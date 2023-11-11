using System;
using System.Collections.Generic;

namespace WideWorldImporters.Database.Models
{
    public partial class Person
    {
        public Person()
        {
            BuyingGroups = new HashSet<BuyingGroup>();
            Cities = new HashSet<City>();
            Colors = new HashSet<Color>();
            Countries = new HashSet<Country>();
            CustomerAlternateContactPeople = new HashSet<Customer>();
            CustomerCategories = new HashSet<CustomerCategory>();
            CustomerLastEditedByNavigations = new HashSet<Customer>();
            CustomerPrimaryContactPeople = new HashSet<Customer>();
            CustomerTransactions = new HashSet<CustomerTransaction>();
            DeliveryMethods = new HashSet<DeliveryMethod>();
            InverseLastEditedByNavigation = new HashSet<Person>();
            InvoiceAccountsPeople = new HashSet<Invoice>();
            InvoiceContactPeople = new HashSet<Invoice>();
            InvoiceLastEditedByNavigations = new HashSet<Invoice>();
            InvoiceLines = new HashSet<InvoiceLine>();
            InvoicePackedByPeople = new HashSet<Invoice>();
            InvoiceSalespersonPeople = new HashSet<Invoice>();
            OrderContactPeople = new HashSet<Order>();
            OrderLastEditedByNavigations = new HashSet<Order>();
            OrderLines = new HashSet<OrderLine>();
            OrderPickedByPeople = new HashSet<Order>();
            OrderSalespersonPeople = new HashSet<Order>();
            PackageTypes = new HashSet<PackageType>();
            PaymentMethods = new HashSet<PaymentMethod>();
            PurchaseOrderContactPeople = new HashSet<PurchaseOrder>();
            PurchaseOrderLastEditedByNavigations = new HashSet<PurchaseOrder>();
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            SpecialDeals = new HashSet<SpecialDeal>();
            StateProvinces = new HashSet<StateProvince>();
            StockGroups = new HashSet<StockGroup>();
            StockItemHoldings = new HashSet<StockItemHolding>();
            StockItemStockGroups = new HashSet<StockItemStockGroup>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
            StockItems = new HashSet<StockItem>();
            SupplierAlternateContactPeople = new HashSet<Supplier>();
            SupplierCategories = new HashSet<SupplierCategory>();
            SupplierLastEditedByNavigations = new HashSet<Supplier>();
            SupplierPrimaryContactPeople = new HashSet<Supplier>();
            SupplierTransactions = new HashSet<SupplierTransaction>();
            SystemParameters = new HashSet<SystemParameter>();
            TransactionTypes = new HashSet<TransactionType>();
        }

        public int PersonId { get; set; }
        public string FullName { get; set; } = null!;
        public string PreferredName { get; set; } = null!;
        public string SearchName { get; set; } = null!;
        public bool IsPermittedToLogon { get; set; }
        public string? LogonName { get; set; }
        public bool IsExternalLogonProvider { get; set; }
        public byte[]? HashedPassword { get; set; }
        public bool IsSystemUser { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsSalesperson { get; set; }
        public string? UserPreferences { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FaxNumber { get; set; }
        public string? EmailAddress { get; set; }
        public byte[]? Photo { get; set; }
        public string? CustomFields { get; set; }
        public string? OtherLanguages { get; set; }
        public int LastEditedBy { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual ICollection<BuyingGroup> BuyingGroups { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<Customer> CustomerAlternateContactPeople { get; set; }
        public virtual ICollection<CustomerCategory> CustomerCategories { get; set; }
        public virtual ICollection<Customer> CustomerLastEditedByNavigations { get; set; }
        public virtual ICollection<Customer> CustomerPrimaryContactPeople { get; set; }
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual ICollection<DeliveryMethod> DeliveryMethods { get; set; }
        public virtual ICollection<Person> InverseLastEditedByNavigation { get; set; }
        public virtual ICollection<Invoice> InvoiceAccountsPeople { get; set; }
        public virtual ICollection<Invoice> InvoiceContactPeople { get; set; }
        public virtual ICollection<Invoice> InvoiceLastEditedByNavigations { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        public virtual ICollection<Invoice> InvoicePackedByPeople { get; set; }
        public virtual ICollection<Invoice> InvoiceSalespersonPeople { get; set; }
        public virtual ICollection<Order> OrderContactPeople { get; set; }
        public virtual ICollection<Order> OrderLastEditedByNavigations { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<Order> OrderPickedByPeople { get; set; }
        public virtual ICollection<Order> OrderSalespersonPeople { get; set; }
        public virtual ICollection<PackageType> PackageTypes { get; set; }
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrderContactPeople { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrderLastEditedByNavigations { get; set; }
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }
        public virtual ICollection<StateProvince> StateProvinces { get; set; }
        public virtual ICollection<StockGroup> StockGroups { get; set; }
        public virtual ICollection<StockItemHolding> StockItemHoldings { get; set; }
        public virtual ICollection<StockItemStockGroup> StockItemStockGroups { get; set; }
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
        public virtual ICollection<StockItem> StockItems { get; set; }
        public virtual ICollection<Supplier> SupplierAlternateContactPeople { get; set; }
        public virtual ICollection<SupplierCategory> SupplierCategories { get; set; }
        public virtual ICollection<Supplier> SupplierLastEditedByNavigations { get; set; }
        public virtual ICollection<Supplier> SupplierPrimaryContactPeople { get; set; }
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }
        public virtual ICollection<SystemParameter> SystemParameters { get; set; }
        public virtual ICollection<TransactionType> TransactionTypes { get; set; }
    }
}
