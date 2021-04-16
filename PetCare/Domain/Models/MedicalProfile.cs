using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class MedicalProfile
    {
      
       public int Id { get; set; }
       public string Name { get; set; }
       public string Weight { get; set; }
       public string Height { get; set; }
       public string Lenght { get; set; }
       public string Eyes { get; set; }
       public string Breed { get; set; }  
       public string Sex { get; set; }
       public string Color{ get; set; }
       public string Description { get; set; }
       public string Photo { get; set; }
       public string Age { get; set; }

       public Provider Provider { get; set; }
       public int ProviderId { get; set; }
       public Pet Pet { get; set; }
       public int PetId { get; set; }
    //   public int CustomerId { get; set; }

        //Medical Record
       public IList<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
       public IList<VaccinationRecord> VaccinationRecords { get; set; } = new List<VaccinationRecord>();


    }
}
