using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IPersonProfileService
    {
        Task<IEnumerable<PersonProfile>> ListAsync();
        Task<PersonProfileResponse> SaveAsync(PersonProfile customer);
        Task<PersonProfileResponse> UpdateAsync(int id, PersonProfile customer);
        Task<PersonProfileResponse> DeleteAsync(int id);
        Task<PersonProfileResponse> FindByIdAsync(int id);
    }
}
