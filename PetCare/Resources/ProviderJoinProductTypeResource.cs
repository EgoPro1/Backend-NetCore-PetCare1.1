using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class ProviderJoinProductTypeResource
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public int TypeProductId  { get; set; }
    }
}
