using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WideWorldImporters.Database.Models
{
    public partial class Country
    {
        public Country()
        {
            StateProvinces = new HashSet<StateProvince>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; } = null!;
        public string FormalName { get; set; } = null!;
        public string? IsoAlpha3Code { get; set; }
        public int? IsoNumericCode { get; set; }
        public string? CountryType { get; set; }
        public long? LatestRecordedPopulation { get; set; }
        public string Continent { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string Subregion { get; set; } = null!;
        public Geometry? Border { get; set; }
        public int LastEditedBy { get; set; }

        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual ICollection<StateProvince> StateProvinces { get; set; }
    }
}
