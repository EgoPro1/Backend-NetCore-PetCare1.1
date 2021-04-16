using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IProviderJoinProductRepository
    {
      Task<IEnumerable<ProviderJoinProduct>> ListByProviderIdAsync(int providerId);
        Task<IEnumerable<ProviderJoinProduct>> ListByProductIdAsync(int productId);
        Task<ProviderJoinProduct> FindByProviderIdAndProductId(int providerId, int productId);
        Task AssignProviderTypeProduct(ProviderJoinProduct providerJoinProduct);
        Task<IEnumerable<ProviderJoinProduct>> ListProductTypeByProviderId(int providerId);
    }
}
