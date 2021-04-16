using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class PersonProfile: Profile
    {
        public int Id { get; set; }
 
        public IList<Pet> Pets { get; set; } = new List<Pet>();
        public IList<PersonRequest> Requests { get; set; } = new List<PersonRequest>();
        public IList<Review> Reviews { get; set; } = new List<Review>();
    }
}
