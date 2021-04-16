using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class SaveRegisterPetResource
    {
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public string Sex { get; set; }
        


    }
}
