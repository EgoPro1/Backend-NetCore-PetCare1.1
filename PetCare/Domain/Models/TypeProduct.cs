using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class TypeProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //  public IList<Product> ListProducts { get; set; } = new List<Product>();
        public IList<ProviderJoinProduct> ProviderJoinProducts { get; set; } = new List<ProviderJoinProduct>();

    }
}
