using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AquaQuality.DAL.Entities
{
    public class WaterStorage
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public string CoordNorth { get; set; }
        public string CoordSouth { get; set; }
        public string City { get; set; }
        public IEnumerable<Measurement> Measurements { get; set; }

    }
}
