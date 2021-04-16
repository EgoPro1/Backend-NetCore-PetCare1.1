using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

      
        //request
        public IList<PersonRequest> Requests { get; set; } = new List<PersonRequest>();
        
        //availability
        public Availability Availability { get; set; }

        //providerJoinTypeProduct
        public int PJPId { get; set; }
        public ProviderJoinProduct PJP { get; set; }

        public int TypeProductId { get; set; }
    }
}
