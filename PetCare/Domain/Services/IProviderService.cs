using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IProviderService
    {
        Task<IEnumerable<Provider>> ListAsync();
        Task<ProviderResponse> SaveAsync(Provider servicesProvider);
        Task<ProviderResponse> UpdateAsync(int id, Provider servicesProvider);
        Task<ProviderResponse> DeleteAsync(int id);
        Task<ProviderResponse> FindByIdAsync(int id);
        Task<IEnumerable<Provider>> ListBySuscriptionPlanIdAsync(int categoryId);

    }
}
