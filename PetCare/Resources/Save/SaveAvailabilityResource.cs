using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources.Save
{
    public class SaveAvailabilityResource
    {
        [Required]
        public string DayAvailability { get; set; }

        [Required]
        [MaxLength(5)]
        public string StartTime { get; set; }

        [Required]
        [MaxLength(5)]
        public string EndTime { get; set; }
    }
}
