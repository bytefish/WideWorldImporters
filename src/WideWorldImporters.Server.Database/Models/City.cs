using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;
using WideWorldImporters.Server.Database.Models;

namespace WideWorldImporters.Server.Database.Models
{
    public partial class City
    {
        public City()
        {
            CustomerDeliveryCities = new HashSet<Customer>();
            CustomerPostalCities = new HashSet<Customer>();
            SupplierDeliveryCities = new HashSet<Supplier>();
            SupplierPostalCities = new HashSet<Supplier>();
            SystemParameterDeliveryCities = new HashSet<SystemParameter>();
            SystemParameterPostalCities = new HashSet<SystemParameter>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
        public int StateProvinceId { get; set; }
        public Geometry? Location { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public int LastEditedBy { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual StateProvince StateProvince { get; set; } = null!;
        public virtual ICollection<Customer> CustomerDeliveryCities { get; set; }
        public virtual ICollection<Customer> CustomerPostalCities { get; set; }
        public virtual ICollection<Supplier> SupplierDeliveryCities { get; set; }
        public virtual ICollection<Supplier> SupplierPostalCities { get; set; }
        public virtual ICollection<SystemParameter> SystemParameterDeliveryCities { get; set; }
        public virtual ICollection<SystemParameter> SystemParameterPostalCities { get; set; }
    }
}
