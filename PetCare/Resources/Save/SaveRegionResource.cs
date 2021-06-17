using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class SaveRegionResource
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string region { get; set; }

    }
}
