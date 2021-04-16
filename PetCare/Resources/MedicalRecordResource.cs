using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class MedicalRecordResource
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
    }
}
