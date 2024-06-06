﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WideWorldImporters.Server.Database.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; }

    public int BillToCustomerId { get; set; }

    public int CustomerCategoryId { get; set; }

    public int? BuyingGroupId { get; set; }

    public int PrimaryContactPersonId { get; set; }

    public int? AlternateContactPersonId { get; set; }

    public int DeliveryMethodId { get; set; }

    public int DeliveryCityId { get; set; }

    public int PostalCityId { get; set; }

    public decimal? CreditLimit { get; set; }

    public DateTime AccountOpenedDate { get; set; }

    public decimal StandardDiscountPercentage { get; set; }

    public bool IsStatementSent { get; set; }

    public bool IsOnCreditHold { get; set; }

    public int PaymentDays { get; set; }

    public string PhoneNumber { get; set; }

    public string FaxNumber { get; set; }

    public string DeliveryRun { get; set; }

    public string RunPosition { get; set; }

    public string WebsiteUrl { get; set; }

    public string DeliveryAddressLine1 { get; set; }

    public string DeliveryAddressLine2 { get; set; }

    public string DeliveryPostalCode { get; set; }

    public Geometry DeliveryLocation { get; set; }

    public string PostalAddressLine1 { get; set; }

    public string PostalAddressLine2 { get; set; }

    public string PostalPostalCode { get; set; }

    public int LastEditedBy { get; set; }

    public virtual Person AlternateContactPerson { get; set; }

    public virtual Customer BillToCustomer { get; set; }

    public virtual BuyingGroup BuyingGroup { get; set; }

    public virtual CustomerCategory CustomerCategory { get; set; }

    public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; } = new List<CustomerTransaction>();

    public virtual City DeliveryCity { get; set; }

    public virtual DeliveryMethod DeliveryMethod { get; set; }

    public virtual ICollection<Customer> InverseBillToCustomer { get; set; } = new List<Customer>();

    public virtual ICollection<Invoice> InvoiceBillToCustomers { get; set; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceCustomers { get; set; } = new List<Invoice>();

    public virtual Person LastEditedByNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual City PostalCity { get; set; }

    public virtual Person PrimaryContactPerson { get; set; }

    public virtual ICollection<SpecialDeal> SpecialDeals { get; set; } = new List<SpecialDeal>();

    public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; } = new List<StockItemTransaction>();
}