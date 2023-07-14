using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using AquaQuality.BLL.DTO.Measurement;

namespace AquaQuality.BLL.DTO.WaterStorage
{
    public class WaterStorageGetDTO
    {
        [Required]
        public int id { get; set; }
        public string Name { get; set; }
        public string CoordNorth { get; set; }
        public string CoordSouth { get; set; }
        public string City { get; set; }
 //     public IEnumerable<MeasurementGetDTO> Measurements { get; set; }
    }
}
