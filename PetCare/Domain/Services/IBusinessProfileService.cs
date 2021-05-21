using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IBusinessProfileService
    {
        Task<IEnumerable<BusinessProfile>> ListAsync();
        Task<BusinessProfileResponse> SaveAsync(BusinessProfile businessProfile);
        Task<BusinessProfileResponse> UpdateAsync(int id, BusinessProfile businessProfile);
        Task<BusinessProfileResponse> DeleteAsync(int id);
        Task<BusinessProfileResponse> FindByIdAsync(int id);
        Task<BusinessProfile> FindByBusinessId(int providerId);
        Task<IEnumerable<BusinessProfile>> ListFindByProviderId(int providerId);

    }
}
