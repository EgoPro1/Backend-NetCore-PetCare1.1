using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IAvailabilityService
    {
        Task<IEnumerable<Availability>> ListAsync();
        Task<AvailabilityResponse> SaveAsync(Availability availability);
        Task<AvailabilityResponse> UpdateAsync(int id, Availability availability);
        Task<AvailabilityResponse> DeleteAsync(int id);
        Task<AvailabilityResponse> SaveByProductIdAsync(int providerId, int productsId, Availability availability);
        Task<IEnumerable<Availability>> ListByProviderIdAndProductIdAsync(int providerId, int productId);
    }
}
