using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class AvailabilityResource
    {
        public int Id { get; set; }
        public string DayAvailability { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
