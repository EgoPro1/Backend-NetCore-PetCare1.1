using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using PetCare.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IMedicalProfileService
    {
        Task<IEnumerable<MedicalProfile>> ListAsync();
        Task<MedicalProfileResponse> SaveAsync(MedicalProfile medicalprofile);
        Task<MedicalProfileResponse> UpdateAsync(int id, MedicalProfile medicalprofile);
        Task<MedicalProfileResponse> DeleteAsync(int id);
        Task<MedicalProfileResponse> SaveByPetIdAsync(int servicesproviderId,int customerId,int petId, MedicalProfile medicalprofile);
        Task<IEnumerable<MedicalProfile>> ListByCustomerIdAndPetIdAsync(int customerId, int petId);

        Task<MedicalProfileResponse> FindByIdAsync(int profileId);
        Task<IEnumerable<MedicalProfile>> ListByPetIdAsync(int petId);
    }
}
