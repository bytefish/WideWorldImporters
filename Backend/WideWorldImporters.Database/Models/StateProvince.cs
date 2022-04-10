using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WideWorldImporters.Database.Models
{
    public partial class StateProvince
    {
        public StateProvince()
        {
            Cities = new HashSet<City>();
        }

        public int StateProvinceId { get; set; }
        public string StateProvinceCode { get; set; } = null!;
        public string StateProvinceName { get; set; } = null!;
        public int CountryId { get; set; }
        public string SalesTerritory { get; set; } = null!;
        public Geometry? Border { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public int LastEditedBy { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual ICollection<City> Cities { get; set; }
    }
}
