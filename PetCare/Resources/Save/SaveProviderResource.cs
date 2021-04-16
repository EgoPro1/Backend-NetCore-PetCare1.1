using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class SaveProviderResource 
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string BusinessName { get; set; }
        [Required]
        [MaxLength(30)]
        public string Address { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

      
        [Required]
        [MaxLength(30)]
        public string Region { get; set; }
        [Required]
        [MaxLength(30)]
        public string Field { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

       // public int SuscriptionPlanId { get; set; }

        //  public Card Card { get; set; }

    }
}
