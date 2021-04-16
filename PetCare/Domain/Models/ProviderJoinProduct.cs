using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class ProviderJoinProduct
    {
        public int  Id { get; set; }

        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
        public int TypeProductId { get; set; }
        public TypeProduct TypeProduct { get; set; }

        public IList<Product> Products { get; set; } = new List<Product>();

    }
}
