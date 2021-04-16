using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class SaveBusinessProfileResource
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        public long Document { get; set; }

        [Required]
        [EmailAddress]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
       //// [Phone]
        public long Phone { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Photo { get; set; }

        public Boolean Owner { get; set; }

    }
}
