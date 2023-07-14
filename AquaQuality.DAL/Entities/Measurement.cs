using System;
using System.ComponentModel.DataAnnotations;

namespace AquaQuality.DAL.Entities
{
    public class Measurement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Ammonia { get; set; }
        public float Phosphates { get; set; }
        public float Ferrum { get; set; }
        public float Nitrates { get; set; }
        public float Nitrities { get; set; }
        public float SuspendedSolids { get; set; }
        public int WaterStorageId { get; set; }
        public WaterStorage WaterStorage { get; set; }
    }
}
