using PetCare.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IMedicalProfileRepository
    {
        Task<IEnumerable<MedicalProfile>> ListAsync();
        Task AddAsyn(MedicalProfile medicalprofile);
        Task<MedicalProfile> FindByIdAsync(int id);
        void Update(MedicalProfile medicalprofile);
        void Remove(MedicalProfile medicalprofile);
       
        Task<IEnumerable<MedicalProfile>> ListByPetIdAsync(int petId);

        
    }
}
