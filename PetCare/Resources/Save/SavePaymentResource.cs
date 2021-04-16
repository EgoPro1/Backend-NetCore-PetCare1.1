using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetCare.Resources
{
    public class SavePaymentResource
    {
        
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public long Number { get; set; }

        [Required]
        public int CVV { get; set; }


        [Required]
        [MaxLength(6)]
        public string DateOfExpiry { get; set; }

      

    }
}
