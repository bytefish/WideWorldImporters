using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace WideWorldImporters.Database.Models
{
    public partial class SystemParameter
    {
        public int SystemParameterId { get; set; }
        public string DeliveryAddressLine1 { get; set; } = null!;
        public string? DeliveryAddressLine2 { get; set; }
        public int DeliveryCityId { get; set; }
        public string DeliveryPostalCode { get; set; } = null!;
        public Geometry DeliveryLocation { get; set; } = null!;
        public string PostalAddressLine1 { get; set; } = null!;
        public string? PostalAddressLine2 { get; set; }
        public int PostalCityId { get; set; }
        public string PostalPostalCode { get; set; } = null!;
        public string ApplicationSettings { get; set; } = null!;
        public int LastEditedBy { get; set; }
        public DateTime LastEditedWhen { get; set; }

        public virtual City DeliveryCity { get; set; } = null!;
        public virtual Person LastEditedByNavigation { get; set; } = null!;
        public virtual City PostalCity { get; set; } = null!;
    }
}
