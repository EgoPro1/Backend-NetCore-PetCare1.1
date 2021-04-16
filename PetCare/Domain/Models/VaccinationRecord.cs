using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class VaccinationRecord
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Create_at { get; set; }

        public MedicalProfile Profile { get; set; }
        public int ProfileId { get; set; }


    }
}
