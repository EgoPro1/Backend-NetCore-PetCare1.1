using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Account
    {
       
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }
        public int RolId { get; set; }

        public PersonProfile PersonProfile { get; set; }
        
        public BusinessProfile BusinessProfile { get; set; }

        public int SubscriptionPlanId { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; }

       
    }
}
