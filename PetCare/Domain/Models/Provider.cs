using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Provider 
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string Region { get; set; }
        public string Field { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        
        public Payment Payment{ get; set; }
        public List<ProviderJoinProduct> ProviderProducts { get; set; }
        public IList<BusinessProfile> BusinessProfiles { get; set; } = new List<BusinessProfile>();
        public IList<MedicalProfile> MedicalProfiles { get; set; } = new List<MedicalProfile>();
        public IList<Review> Reviews { get; set; } = new List<Review>();

    }
}
