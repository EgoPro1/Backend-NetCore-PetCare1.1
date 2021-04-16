using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class SaveMedicalProfileResource
    {
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Weight { get; set; }
        [Required]
        public string Height { get; set; }
        [Required]
        public string Lenght { get; set; }
        [Required]
        public string Eyes { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public string Age { get; set; }
        

        //public int PetId { get; set; }

    }
}
