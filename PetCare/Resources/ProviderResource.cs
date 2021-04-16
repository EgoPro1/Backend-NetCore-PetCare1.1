using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class ProviderResource
    {
        public int Id { get; set; }

        public string BusinessName { get; set; }

        public string Region { get; set; }

        public string Field { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

       // public int SuscriptionPlanId { get; set; }

    }
}
