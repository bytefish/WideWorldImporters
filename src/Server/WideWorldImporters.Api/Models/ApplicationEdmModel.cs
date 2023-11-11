// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.Spatial;
using WideWorldImporters.Database.Models;

namespace WideWorldImporters.Api.Models
{
    public static class ApplicationEdmModel
    {
        public static IEdmModel GetEdmModel()
        {
            var modelBuilder = new ODataConventionModelBuilder();

            modelBuilder.Namespace = "WideWorldImportersService";

            modelBuilder.EntitySet<BuyingGroup>("BuyingGroups");
            modelBuilder.EntitySet<City>("Cities");
            modelBuilder.EntitySet<ColdRoomTemperature>("ColdRoomTemperatures");
            modelBuilder.EntitySet<Color>("Colors");
            modelBuilder.EntitySet<Country>("Countries");
            modelBuilder.EntitySet<Customer>("Customers");
            modelBuilder.EntitySet<CustomerCategory>("CustomerCategories");
            modelBuilder.EntitySet<CustomerTransaction>("CustomerTransactions");
            modelBuilder.EntitySet<DeliveryMethod>("DeliveryMethods");
            modelBuilder.EntitySet<Invoice>("Invoices");
            modelBuilder.EntitySet<InvoiceLine>("InvoiceLines");
            modelBuilder.EntitySet<Order>("Orders");
            modelBuilder.EntitySet<OrderLine>("OrderLines");
            modelBuilder.EntitySet<PackageType>("PackageTypes");
            modelBuilder.EntitySet<PaymentMethod>("PaymentMethods");
            modelBuilder.EntitySet<Person>("People");
            modelBuilder.EntitySet<PurchaseOrder>("PurchaseOrders");
            modelBuilder.EntitySet<PurchaseOrderLine>("PurchaseOrderLines");
            modelBuilder.EntitySet<SpecialDeal>("SpecialDeals");
            modelBuilder.EntitySet<StateProvince>("StateProvinces");
            modelBuilder.EntitySet<StockGroup>("StockGroups");
            modelBuilder.EntitySet<StockItem>("StockItems");
            modelBuilder.EntitySet<StockItemHolding>("StockItemHoldings");
            modelBuilder.EntitySet<StockItemStockGroup>("StockItemStockGroups");
            modelBuilder.EntitySet<StockItemTransaction>("StockItemTransactions");
            modelBuilder.EntitySet<Supplier>("Suppliers");
            modelBuilder.EntitySet<SupplierCategory>("SupplierCategories");
            modelBuilder.EntitySet<SupplierTransaction>("SupplierTransactions");
            modelBuilder.EntitySet<SystemParameter>("SystemParameters");
            modelBuilder.EntitySet<TransactionType>("TransactionTypes");
            modelBuilder.EntitySet<VehicleTemperature>("VehicleTemperatures");

            // Configure EntityTypes, that could not be mapped using Conventions. We
            // could also add Attributes to the Model, but I want to avoid mixing the
            // EF Core Fluent API and Attributes.
            modelBuilder.EntityType<StockItemHolding>().HasKey(s => new { s.StockItemId });

            // Build the Spatial Types:
            BuildGeometryTypes(modelBuilder);

            // Send as Lower Camel Case Properties, so the JSON looks better:
            modelBuilder.EnableLowerCamelCase();

            return modelBuilder.GetEdmModel();
        }

        /// <summary>
        /// EF Core Scaffolding generates NetTopologySuite types for SQL Server 
        /// Spatial types. There are incompatible with OData, which only supports 
        /// Microsoft.Spatial types. 
        /// 
        /// So we rewrite the convention-based EDM model here to ignore the NetTopology 
        /// Suite properties and use our custom properties instead.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder to configure the EDM model</param>
        private static void BuildGeometryTypes(ODataConventionModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Geography>();

            modelBuilder.EntityType<City>().Ignore(x => x.Location);
            modelBuilder.EntityType<Country>().Ignore(x => x.Border);
            modelBuilder.EntityType<Customer>().Ignore(x => x.DeliveryLocation);
            modelBuilder.EntityType<Supplier>().Ignore(x => x.DeliveryLocation);
            modelBuilder.EntityType<StateProvince>().Ignore(x => x.Border);
            modelBuilder.EntityType<SystemParameter>().Ignore(x => x.DeliveryLocation);

            // We will rewrite the Property Name from EdmLocation -> Location, so
            // it matches fine with the EF Core Model for filtering.
            modelBuilder.OnModelCreating += (builder) =>
            {
                foreach (StructuralTypeConfiguration typeConfiguration in builder.StructuralTypes)
                {
                    foreach (PropertyConfiguration property in typeConfiguration.Properties)
                    {
                        // Let's not introduce magic strings and make it more safe for refactorings:
                        string propertyName = (typeConfiguration.Name, property.Name) switch
                        {
                            (nameof(City), nameof(City.EdmLocation)) => nameof(City.Location),
                            (nameof(Country), nameof(Country.EdmBorder)) => nameof(Country.Border),
                            (nameof(Customer), nameof(Customer.EdmDeliveryLocation)) => nameof(Customer.DeliveryLocation),
                            (nameof(Supplier), nameof(Supplier.EdmDeliveryLocation)) => nameof(Supplier.DeliveryLocation),
                            (nameof(StateProvince), nameof(StateProvince.EdmBorder)) => nameof(StateProvince.Border),
                            (nameof(SystemParameter), nameof(SystemParameter.EdmDeliveryLocation)) => nameof(SystemParameter.DeliveryLocation),
                            _ => property.Name,
                        };

                        property.Name = propertyName;
                    }
                }
            };
        }
    }
}