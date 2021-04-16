using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IBusinessProfileRepository
    {
        Task<IEnumerable<BusinessProfile>> ListAsync();
        Task AddAsyn(BusinessProfile businessProfile);
        Task<PersonProfile> FindByIdAsync(int id);
        void Update(BusinessProfile businessProfile);
        void Remove(BusinessProfile businessProfile);
        Task<BusinessProfile> FindByProviderId(int providerId);
        Task<IEnumerable<BusinessProfile>> ListFindByProviderId(int providerId);

    }
}
