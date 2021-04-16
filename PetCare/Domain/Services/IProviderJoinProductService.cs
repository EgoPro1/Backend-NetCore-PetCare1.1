using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using PetCare.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IProviderJoinProductService
    {
      Task<ProviderJoinProductResponse> AssignProviderProduct(int providerId, int typeproductId);
        Task<IEnumerable<ProviderJoinProduct>> ListByProviderIdAsync(int providerId);
      
    }
}
