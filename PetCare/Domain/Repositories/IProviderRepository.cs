using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IProviderRepository
    {
        Task<IEnumerable<Provider>> ListAsync();
        Task AddAsyn(Provider servicesProvider);
        Task<Provider> FindByIdAsync(int id);
        void Update(Provider servicesProvider);
        void Remove(Provider servicesProvider);
        Task<IEnumerable<Provider>> ListBySuscriptionPlanIdAsync(int categoryId);
        


    }
}
