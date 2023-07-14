using System;
using System.ComponentModel.DataAnnotations;

namespace AquaQuality.BLL.DTO.WaterStorage
{
    public class WaterStoragePostDTO
    {
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(30, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(10, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string CoordNorth { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(10, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string CoordSouth { get; set; }
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(60, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string City { get; set; }
    }
}
