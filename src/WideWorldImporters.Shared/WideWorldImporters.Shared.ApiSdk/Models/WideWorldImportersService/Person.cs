// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace WideWorldImporters.Shared.ApiSdk.Models.WideWorldImportersService {
    public class Person : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The buyingGroups property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<BuyingGroup>? BuyingGroups { get; set; }
#nullable restore
#else
        public List<BuyingGroup> BuyingGroups { get; set; }
#endif
        /// <summary>The cities property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<City>? Cities { get; set; }
#nullable restore
#else
        public List<City> Cities { get; set; }
#endif
        /// <summary>The colors property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Color>? Colors { get; set; }
#nullable restore
#else
        public List<Color> Colors { get; set; }
#endif
        /// <summary>The countries property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Country>? Countries { get; set; }
#nullable restore
#else
        public List<Country> Countries { get; set; }
#endif
        /// <summary>The customerAlternateContactPeople property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Customer>? CustomerAlternateContactPeople { get; set; }
#nullable restore
#else
        public List<Customer> CustomerAlternateContactPeople { get; set; }
#endif
        /// <summary>The customerCategories property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<CustomerCategory>? CustomerCategories { get; set; }
#nullable restore
#else
        public List<CustomerCategory> CustomerCategories { get; set; }
#endif
        /// <summary>The customerLastEditedByNavigations property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Customer>? CustomerLastEditedByNavigations { get; set; }
#nullable restore
#else
        public List<Customer> CustomerLastEditedByNavigations { get; set; }
#endif
        /// <summary>The customerPrimaryContactPeople property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Customer>? CustomerPrimaryContactPeople { get; set; }
#nullable restore
#else
        public List<Customer> CustomerPrimaryContactPeople { get; set; }
#endif
        /// <summary>The customerTransactions property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<CustomerTransaction>? CustomerTransactions { get; set; }
#nullable restore
#else
        public List<CustomerTransaction> CustomerTransactions { get; set; }
#endif
        /// <summary>The customFields property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? CustomFields { get; set; }
#nullable restore
#else
        public string CustomFields { get; set; }
#endif
        /// <summary>The deliveryMethods property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<DeliveryMethod>? DeliveryMethods { get; set; }
#nullable restore
#else
        public List<DeliveryMethod> DeliveryMethods { get; set; }
#endif
        /// <summary>The emailAddress property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? EmailAddress { get; set; }
#nullable restore
#else
        public string EmailAddress { get; set; }
#endif
        /// <summary>The faxNumber property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? FaxNumber { get; set; }
#nullable restore
#else
        public string FaxNumber { get; set; }
#endif
        /// <summary>The fullName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? FullName { get; set; }
#nullable restore
#else
        public string FullName { get; set; }
#endif
        /// <summary>The hashedPassword property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public byte[]? HashedPassword { get; set; }
#nullable restore
#else
        public byte[] HashedPassword { get; set; }
#endif
        /// <summary>The inverseLastEditedByNavigation property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Person>? InverseLastEditedByNavigation { get; set; }
#nullable restore
#else
        public List<Person> InverseLastEditedByNavigation { get; set; }
#endif
        /// <summary>The invoiceAccountsPeople property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Invoice>? InvoiceAccountsPeople { get; set; }
#nullable restore
#else
        public List<Invoice> InvoiceAccountsPeople { get; set; }
#endif
        /// <summary>The invoiceContactPeople property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Invoice>? InvoiceContactPeople { get; set; }
#nullable restore
#else
        public List<Invoice> InvoiceContactPeople { get; set; }
#endif
        /// <summary>The invoiceLastEditedByNavigations property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Invoice>? InvoiceLastEditedByNavigations { get; set; }
#nullable restore
#else
        public List<Invoice> InvoiceLastEditedByNavigations { get; set; }
#endif
        /// <summary>The invoiceLines property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<InvoiceLine>? InvoiceLines { get; set; }
#nullable restore
#else
        public List<InvoiceLine> InvoiceLines { get; set; }
#endif
        /// <summary>The invoicePackedByPeople property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Invoice>? InvoicePackedByPeople { get; set; }
#nullable restore
#else
        public List<Invoice> InvoicePackedByPeople { get; set; }
#endif
        /// <summary>The invoiceSalespersonPeople property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Invoice>? InvoiceSalespersonPeople { get; set; }
#nullable restore
#else
        public List<Invoice> InvoiceSalespersonPeople { get; set; }
#endif
        /// <summary>The isEmployee property</summary>
        public bool? IsEmployee { get; set; }
        /// <summary>The isExternalLogonProvider property</summary>
        public bool? IsExternalLogonProvider { get; set; }
        /// <summary>The isPermittedToLogon property</summary>
        public bool? IsPermittedToLogon { get; set; }
        /// <summary>The isSalesperson property</summary>
        public bool? IsSalesperson { get; set; }
        /// <summary>The isSystemUser property</summary>
        public bool? IsSystemUser { get; set; }
        /// <summary>The lastEditedBy property</summary>
        public int? LastEditedBy { get; set; }
        /// <summary>The lastEditedByNavigation property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public Person? LastEditedByNavigation { get; set; }
#nullable restore
#else
        public Person LastEditedByNavigation { get; set; }
#endif
        /// <summary>The logonName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? LogonName { get; set; }
#nullable restore
#else
        public string LogonName { get; set; }
#endif
        /// <summary>The orderContactPeople property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Order>? OrderContactPeople { get; set; }
#nullable restore
#else
        public List<Order> OrderContactPeople { get; set; }
#endif
        /// <summary>The orderLastEditedByNavigations property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Order>? OrderLastEditedByNavigations { get; set; }
#nullable restore
#else
        public List<Order> OrderLastEditedByNavigations { get; set; }
#endif
        /// <summary>The orderLines property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<OrderLine>? OrderLines { get; set; }
#nullable restore
#else
        public List<OrderLine> OrderLines { get; set; }
#endif
        /// <summary>The orderPickedByPeople property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Order>? OrderPickedByPeople { get; set; }
#nullable restore
#else
        public List<Order> OrderPickedByPeople { get; set; }
#endif
        /// <summary>The orderSalespersonPeople property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Order>? OrderSalespersonPeople { get; set; }
#nullable restore
#else
        public List<Order> OrderSalespersonPeople { get; set; }
#endif
        /// <summary>The otherLanguages property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? OtherLanguages { get; set; }
#nullable restore
#else
        public string OtherLanguages { get; set; }
#endif
        /// <summary>The packageTypes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<PackageType>? PackageTypes { get; set; }
#nullable restore
#else
        public List<PackageType> PackageTypes { get; set; }
#endif
        /// <summary>The paymentMethods property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<PaymentMethod>? PaymentMethods { get; set; }
#nullable restore
#else
        public List<PaymentMethod> PaymentMethods { get; set; }
#endif
        /// <summary>The personId property</summary>
        public int? PersonId { get; set; }
        /// <summary>The phoneNumber property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PhoneNumber { get; set; }
#nullable restore
#else
        public string PhoneNumber { get; set; }
#endif
        /// <summary>The photo property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public byte[]? Photo { get; set; }
#nullable restore
#else
        public byte[] Photo { get; set; }
#endif
        /// <summary>The preferredName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PreferredName { get; set; }
#nullable restore
#else
        public string PreferredName { get; set; }
#endif
        /// <summary>The purchaseOrderContactPeople property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<PurchaseOrder>? PurchaseOrderContactPeople { get; set; }
#nullable restore
#else
        public List<PurchaseOrder> PurchaseOrderContactPeople { get; set; }
#endif
        /// <summary>The purchaseOrderLastEditedByNavigations property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<PurchaseOrder>? PurchaseOrderLastEditedByNavigations { get; set; }
#nullable restore
#else
        public List<PurchaseOrder> PurchaseOrderLastEditedByNavigations { get; set; }
#endif
        /// <summary>The purchaseOrderLines property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<PurchaseOrderLine>? PurchaseOrderLines { get; set; }
#nullable restore
#else
        public List<PurchaseOrderLine> PurchaseOrderLines { get; set; }
#endif
        /// <summary>The searchName property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SearchName { get; set; }
#nullable restore
#else
        public string SearchName { get; set; }
#endif
        /// <summary>The specialDeals property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<SpecialDeal>? SpecialDeals { get; set; }
#nullable restore
#else
        public List<SpecialDeal> SpecialDeals { get; set; }
#endif
        /// <summary>The stateProvinces property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<StateProvince>? StateProvinces { get; set; }
#nullable restore
#else
        public List<StateProvince> StateProvinces { get; set; }
#endif
        /// <summary>The stockGroups property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<StockGroup>? StockGroups { get; set; }
#nullable restore
#else
        public List<StockGroup> StockGroups { get; set; }
#endif
        /// <summary>The stockItemHoldings property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<StockItemHolding>? StockItemHoldings { get; set; }
#nullable restore
#else
        public List<StockItemHolding> StockItemHoldings { get; set; }
#endif
        /// <summary>The stockItems property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<StockItem>? StockItems { get; set; }
#nullable restore
#else
        public List<StockItem> StockItems { get; set; }
#endif
        /// <summary>The stockItemStockGroups property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<StockItemStockGroup>? StockItemStockGroups { get; set; }
#nullable restore
#else
        public List<StockItemStockGroup> StockItemStockGroups { get; set; }
#endif
        /// <summary>The stockItemTransactions property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<StockItemTransaction>? StockItemTransactions { get; set; }
#nullable restore
#else
        public List<StockItemTransaction> StockItemTransactions { get; set; }
#endif
        /// <summary>The supplierAlternateContactPeople property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Supplier>? SupplierAlternateContactPeople { get; set; }
#nullable restore
#else
        public List<Supplier> SupplierAlternateContactPeople { get; set; }
#endif
        /// <summary>The supplierCategories property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<SupplierCategory>? SupplierCategories { get; set; }
#nullable restore
#else
        public List<SupplierCategory> SupplierCategories { get; set; }
#endif
        /// <summary>The supplierLastEditedByNavigations property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Supplier>? SupplierLastEditedByNavigations { get; set; }
#nullable restore
#else
        public List<Supplier> SupplierLastEditedByNavigations { get; set; }
#endif
        /// <summary>The supplierPrimaryContactPeople property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Supplier>? SupplierPrimaryContactPeople { get; set; }
#nullable restore
#else
        public List<Supplier> SupplierPrimaryContactPeople { get; set; }
#endif
        /// <summary>The supplierTransactions property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<SupplierTransaction>? SupplierTransactions { get; set; }
#nullable restore
#else
        public List<SupplierTransaction> SupplierTransactions { get; set; }
#endif
        /// <summary>The systemParameters property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<SystemParameter>? SystemParameters { get; set; }
#nullable restore
#else
        public List<SystemParameter> SystemParameters { get; set; }
#endif
        /// <summary>The transactionTypes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<TransactionType>? TransactionTypes { get; set; }
#nullable restore
#else
        public List<TransactionType> TransactionTypes { get; set; }
#endif
        /// <summary>The userPreferences property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? UserPreferences { get; set; }
#nullable restore
#else
        public string UserPreferences { get; set; }
#endif
        /// <summary>
        /// Instantiates a new Person and sets the default values.
        /// </summary>
        public Person() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Person CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Person();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"buyingGroups", n => { BuyingGroups = n.GetCollectionOfObjectValues<BuyingGroup>(BuyingGroup.CreateFromDiscriminatorValue)?.ToList(); } },
                {"cities", n => { Cities = n.GetCollectionOfObjectValues<City>(City.CreateFromDiscriminatorValue)?.ToList(); } },
                {"colors", n => { Colors = n.GetCollectionOfObjectValues<Color>(Color.CreateFromDiscriminatorValue)?.ToList(); } },
                {"countries", n => { Countries = n.GetCollectionOfObjectValues<Country>(Country.CreateFromDiscriminatorValue)?.ToList(); } },
                {"customFields", n => { CustomFields = n.GetStringValue(); } },
                {"customerAlternateContactPeople", n => { CustomerAlternateContactPeople = n.GetCollectionOfObjectValues<Customer>(Customer.CreateFromDiscriminatorValue)?.ToList(); } },
                {"customerCategories", n => { CustomerCategories = n.GetCollectionOfObjectValues<CustomerCategory>(CustomerCategory.CreateFromDiscriminatorValue)?.ToList(); } },
                {"customerLastEditedByNavigations", n => { CustomerLastEditedByNavigations = n.GetCollectionOfObjectValues<Customer>(Customer.CreateFromDiscriminatorValue)?.ToList(); } },
                {"customerPrimaryContactPeople", n => { CustomerPrimaryContactPeople = n.GetCollectionOfObjectValues<Customer>(Customer.CreateFromDiscriminatorValue)?.ToList(); } },
                {"customerTransactions", n => { CustomerTransactions = n.GetCollectionOfObjectValues<CustomerTransaction>(CustomerTransaction.CreateFromDiscriminatorValue)?.ToList(); } },
                {"deliveryMethods", n => { DeliveryMethods = n.GetCollectionOfObjectValues<DeliveryMethod>(DeliveryMethod.CreateFromDiscriminatorValue)?.ToList(); } },
                {"emailAddress", n => { EmailAddress = n.GetStringValue(); } },
                {"faxNumber", n => { FaxNumber = n.GetStringValue(); } },
                {"fullName", n => { FullName = n.GetStringValue(); } },
                {"hashedPassword", n => { HashedPassword = n.GetByteArrayValue(); } },
                {"inverseLastEditedByNavigation", n => { InverseLastEditedByNavigation = n.GetCollectionOfObjectValues<Person>(Person.CreateFromDiscriminatorValue)?.ToList(); } },
                {"invoiceAccountsPeople", n => { InvoiceAccountsPeople = n.GetCollectionOfObjectValues<Invoice>(Invoice.CreateFromDiscriminatorValue)?.ToList(); } },
                {"invoiceContactPeople", n => { InvoiceContactPeople = n.GetCollectionOfObjectValues<Invoice>(Invoice.CreateFromDiscriminatorValue)?.ToList(); } },
                {"invoiceLastEditedByNavigations", n => { InvoiceLastEditedByNavigations = n.GetCollectionOfObjectValues<Invoice>(Invoice.CreateFromDiscriminatorValue)?.ToList(); } },
                {"invoiceLines", n => { InvoiceLines = n.GetCollectionOfObjectValues<InvoiceLine>(InvoiceLine.CreateFromDiscriminatorValue)?.ToList(); } },
                {"invoicePackedByPeople", n => { InvoicePackedByPeople = n.GetCollectionOfObjectValues<Invoice>(Invoice.CreateFromDiscriminatorValue)?.ToList(); } },
                {"invoiceSalespersonPeople", n => { InvoiceSalespersonPeople = n.GetCollectionOfObjectValues<Invoice>(Invoice.CreateFromDiscriminatorValue)?.ToList(); } },
                {"isEmployee", n => { IsEmployee = n.GetBoolValue(); } },
                {"isExternalLogonProvider", n => { IsExternalLogonProvider = n.GetBoolValue(); } },
                {"isPermittedToLogon", n => { IsPermittedToLogon = n.GetBoolValue(); } },
                {"isSalesperson", n => { IsSalesperson = n.GetBoolValue(); } },
                {"isSystemUser", n => { IsSystemUser = n.GetBoolValue(); } },
                {"lastEditedBy", n => { LastEditedBy = n.GetIntValue(); } },
                {"lastEditedByNavigation", n => { LastEditedByNavigation = n.GetObjectValue<Person>(Person.CreateFromDiscriminatorValue); } },
                {"logonName", n => { LogonName = n.GetStringValue(); } },
                {"orderContactPeople", n => { OrderContactPeople = n.GetCollectionOfObjectValues<Order>(Order.CreateFromDiscriminatorValue)?.ToList(); } },
                {"orderLastEditedByNavigations", n => { OrderLastEditedByNavigations = n.GetCollectionOfObjectValues<Order>(Order.CreateFromDiscriminatorValue)?.ToList(); } },
                {"orderLines", n => { OrderLines = n.GetCollectionOfObjectValues<OrderLine>(OrderLine.CreateFromDiscriminatorValue)?.ToList(); } },
                {"orderPickedByPeople", n => { OrderPickedByPeople = n.GetCollectionOfObjectValues<Order>(Order.CreateFromDiscriminatorValue)?.ToList(); } },
                {"orderSalespersonPeople", n => { OrderSalespersonPeople = n.GetCollectionOfObjectValues<Order>(Order.CreateFromDiscriminatorValue)?.ToList(); } },
                {"otherLanguages", n => { OtherLanguages = n.GetStringValue(); } },
                {"packageTypes", n => { PackageTypes = n.GetCollectionOfObjectValues<PackageType>(PackageType.CreateFromDiscriminatorValue)?.ToList(); } },
                {"paymentMethods", n => { PaymentMethods = n.GetCollectionOfObjectValues<PaymentMethod>(PaymentMethod.CreateFromDiscriminatorValue)?.ToList(); } },
                {"personId", n => { PersonId = n.GetIntValue(); } },
                {"phoneNumber", n => { PhoneNumber = n.GetStringValue(); } },
                {"photo", n => { Photo = n.GetByteArrayValue(); } },
                {"preferredName", n => { PreferredName = n.GetStringValue(); } },
                {"purchaseOrderContactPeople", n => { PurchaseOrderContactPeople = n.GetCollectionOfObjectValues<PurchaseOrder>(PurchaseOrder.CreateFromDiscriminatorValue)?.ToList(); } },
                {"purchaseOrderLastEditedByNavigations", n => { PurchaseOrderLastEditedByNavigations = n.GetCollectionOfObjectValues<PurchaseOrder>(PurchaseOrder.CreateFromDiscriminatorValue)?.ToList(); } },
                {"purchaseOrderLines", n => { PurchaseOrderLines = n.GetCollectionOfObjectValues<PurchaseOrderLine>(PurchaseOrderLine.CreateFromDiscriminatorValue)?.ToList(); } },
                {"searchName", n => { SearchName = n.GetStringValue(); } },
                {"specialDeals", n => { SpecialDeals = n.GetCollectionOfObjectValues<SpecialDeal>(SpecialDeal.CreateFromDiscriminatorValue)?.ToList(); } },
                {"stateProvinces", n => { StateProvinces = n.GetCollectionOfObjectValues<StateProvince>(StateProvince.CreateFromDiscriminatorValue)?.ToList(); } },
                {"stockGroups", n => { StockGroups = n.GetCollectionOfObjectValues<StockGroup>(StockGroup.CreateFromDiscriminatorValue)?.ToList(); } },
                {"stockItemHoldings", n => { StockItemHoldings = n.GetCollectionOfObjectValues<StockItemHolding>(StockItemHolding.CreateFromDiscriminatorValue)?.ToList(); } },
                {"stockItemStockGroups", n => { StockItemStockGroups = n.GetCollectionOfObjectValues<StockItemStockGroup>(StockItemStockGroup.CreateFromDiscriminatorValue)?.ToList(); } },
                {"stockItemTransactions", n => { StockItemTransactions = n.GetCollectionOfObjectValues<StockItemTransaction>(StockItemTransaction.CreateFromDiscriminatorValue)?.ToList(); } },
                {"stockItems", n => { StockItems = n.GetCollectionOfObjectValues<StockItem>(StockItem.CreateFromDiscriminatorValue)?.ToList(); } },
                {"supplierAlternateContactPeople", n => { SupplierAlternateContactPeople = n.GetCollectionOfObjectValues<Supplier>(Supplier.CreateFromDiscriminatorValue)?.ToList(); } },
                {"supplierCategories", n => { SupplierCategories = n.GetCollectionOfObjectValues<SupplierCategory>(SupplierCategory.CreateFromDiscriminatorValue)?.ToList(); } },
                {"supplierLastEditedByNavigations", n => { SupplierLastEditedByNavigations = n.GetCollectionOfObjectValues<Supplier>(Supplier.CreateFromDiscriminatorValue)?.ToList(); } },
                {"supplierPrimaryContactPeople", n => { SupplierPrimaryContactPeople = n.GetCollectionOfObjectValues<Supplier>(Supplier.CreateFromDiscriminatorValue)?.ToList(); } },
                {"supplierTransactions", n => { SupplierTransactions = n.GetCollectionOfObjectValues<SupplierTransaction>(SupplierTransaction.CreateFromDiscriminatorValue)?.ToList(); } },
                {"systemParameters", n => { SystemParameters = n.GetCollectionOfObjectValues<SystemParameter>(SystemParameter.CreateFromDiscriminatorValue)?.ToList(); } },
                {"transactionTypes", n => { TransactionTypes = n.GetCollectionOfObjectValues<TransactionType>(TransactionType.CreateFromDiscriminatorValue)?.ToList(); } },
                {"userPreferences", n => { UserPreferences = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<BuyingGroup>("buyingGroups", BuyingGroups);
            writer.WriteCollectionOfObjectValues<City>("cities", Cities);
            writer.WriteCollectionOfObjectValues<Color>("colors", Colors);
            writer.WriteCollectionOfObjectValues<Country>("countries", Countries);
            writer.WriteCollectionOfObjectValues<Customer>("customerAlternateContactPeople", CustomerAlternateContactPeople);
            writer.WriteCollectionOfObjectValues<CustomerCategory>("customerCategories", CustomerCategories);
            writer.WriteCollectionOfObjectValues<Customer>("customerLastEditedByNavigations", CustomerLastEditedByNavigations);
            writer.WriteCollectionOfObjectValues<Customer>("customerPrimaryContactPeople", CustomerPrimaryContactPeople);
            writer.WriteCollectionOfObjectValues<CustomerTransaction>("customerTransactions", CustomerTransactions);
            writer.WriteStringValue("customFields", CustomFields);
            writer.WriteCollectionOfObjectValues<DeliveryMethod>("deliveryMethods", DeliveryMethods);
            writer.WriteStringValue("emailAddress", EmailAddress);
            writer.WriteStringValue("faxNumber", FaxNumber);
            writer.WriteStringValue("fullName", FullName);
            writer.WriteByteArrayValue("hashedPassword", HashedPassword);
            writer.WriteCollectionOfObjectValues<Person>("inverseLastEditedByNavigation", InverseLastEditedByNavigation);
            writer.WriteCollectionOfObjectValues<Invoice>("invoiceAccountsPeople", InvoiceAccountsPeople);
            writer.WriteCollectionOfObjectValues<Invoice>("invoiceContactPeople", InvoiceContactPeople);
            writer.WriteCollectionOfObjectValues<Invoice>("invoiceLastEditedByNavigations", InvoiceLastEditedByNavigations);
            writer.WriteCollectionOfObjectValues<InvoiceLine>("invoiceLines", InvoiceLines);
            writer.WriteCollectionOfObjectValues<Invoice>("invoicePackedByPeople", InvoicePackedByPeople);
            writer.WriteCollectionOfObjectValues<Invoice>("invoiceSalespersonPeople", InvoiceSalespersonPeople);
            writer.WriteBoolValue("isEmployee", IsEmployee);
            writer.WriteBoolValue("isExternalLogonProvider", IsExternalLogonProvider);
            writer.WriteBoolValue("isPermittedToLogon", IsPermittedToLogon);
            writer.WriteBoolValue("isSalesperson", IsSalesperson);
            writer.WriteBoolValue("isSystemUser", IsSystemUser);
            writer.WriteIntValue("lastEditedBy", LastEditedBy);
            writer.WriteObjectValue<Person>("lastEditedByNavigation", LastEditedByNavigation);
            writer.WriteStringValue("logonName", LogonName);
            writer.WriteCollectionOfObjectValues<Order>("orderContactPeople", OrderContactPeople);
            writer.WriteCollectionOfObjectValues<Order>("orderLastEditedByNavigations", OrderLastEditedByNavigations);
            writer.WriteCollectionOfObjectValues<OrderLine>("orderLines", OrderLines);
            writer.WriteCollectionOfObjectValues<Order>("orderPickedByPeople", OrderPickedByPeople);
            writer.WriteCollectionOfObjectValues<Order>("orderSalespersonPeople", OrderSalespersonPeople);
            writer.WriteStringValue("otherLanguages", OtherLanguages);
            writer.WriteCollectionOfObjectValues<PackageType>("packageTypes", PackageTypes);
            writer.WriteCollectionOfObjectValues<PaymentMethod>("paymentMethods", PaymentMethods);
            writer.WriteIntValue("personId", PersonId);
            writer.WriteStringValue("phoneNumber", PhoneNumber);
            writer.WriteByteArrayValue("photo", Photo);
            writer.WriteStringValue("preferredName", PreferredName);
            writer.WriteCollectionOfObjectValues<PurchaseOrder>("purchaseOrderContactPeople", PurchaseOrderContactPeople);
            writer.WriteCollectionOfObjectValues<PurchaseOrder>("purchaseOrderLastEditedByNavigations", PurchaseOrderLastEditedByNavigations);
            writer.WriteCollectionOfObjectValues<PurchaseOrderLine>("purchaseOrderLines", PurchaseOrderLines);
            writer.WriteStringValue("searchName", SearchName);
            writer.WriteCollectionOfObjectValues<SpecialDeal>("specialDeals", SpecialDeals);
            writer.WriteCollectionOfObjectValues<StateProvince>("stateProvinces", StateProvinces);
            writer.WriteCollectionOfObjectValues<StockGroup>("stockGroups", StockGroups);
            writer.WriteCollectionOfObjectValues<StockItemHolding>("stockItemHoldings", StockItemHoldings);
            writer.WriteCollectionOfObjectValues<StockItem>("stockItems", StockItems);
            writer.WriteCollectionOfObjectValues<StockItemStockGroup>("stockItemStockGroups", StockItemStockGroups);
            writer.WriteCollectionOfObjectValues<StockItemTransaction>("stockItemTransactions", StockItemTransactions);
            writer.WriteCollectionOfObjectValues<Supplier>("supplierAlternateContactPeople", SupplierAlternateContactPeople);
            writer.WriteCollectionOfObjectValues<SupplierCategory>("supplierCategories", SupplierCategories);
            writer.WriteCollectionOfObjectValues<Supplier>("supplierLastEditedByNavigations", SupplierLastEditedByNavigations);
            writer.WriteCollectionOfObjectValues<Supplier>("supplierPrimaryContactPeople", SupplierPrimaryContactPeople);
            writer.WriteCollectionOfObjectValues<SupplierTransaction>("supplierTransactions", SupplierTransactions);
            writer.WriteCollectionOfObjectValues<SystemParameter>("systemParameters", SystemParameters);
            writer.WriteCollectionOfObjectValues<TransactionType>("transactionTypes", TransactionTypes);
            writer.WriteStringValue("userPreferences", UserPreferences);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}