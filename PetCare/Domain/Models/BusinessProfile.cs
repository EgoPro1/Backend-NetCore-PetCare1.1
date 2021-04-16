using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class BusinessProfile: Profile
    {
        public int Id { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }

        public bool Owner { get; set; }

        public string Photo { get; set; }
        //

    }
}
