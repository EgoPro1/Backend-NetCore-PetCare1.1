using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }

        public int MedicalProfileId { get; set; }
        public MedicalProfile MedicalProfile { get; set; }

    }
}
