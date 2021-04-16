using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources.Save
{
    public class SaveReviewResource
    {
        [Required]
        public int Qualification { get; set; }

        [Required]
        [MaxLength(50)]
        public string Commentary { get; set; }
    }
}
