using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources.Save
{
    public class SaveMedicalRecordResource
    {
     
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
    }
}
