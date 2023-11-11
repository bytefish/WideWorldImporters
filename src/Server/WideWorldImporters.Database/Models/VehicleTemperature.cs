using System;
using System.Collections.Generic;

namespace WideWorldImporters.Database.Models
{
    public partial class VehicleTemperature
    {
        public long VehicleTemperatureId { get; set; }
        public string VehicleRegistration { get; set; } = null!;
        public int ChillerSensorNumber { get; set; }
        public DateTime RecordedWhen { get; set; }
        public decimal Temperature { get; set; }
        public string? FullSensorData { get; set; }
        public bool IsCompressed { get; set; }
        public byte[]? CompressedSensorData { get; set; }
    }
}
