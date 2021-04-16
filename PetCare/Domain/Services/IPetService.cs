using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using PetCare.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> ListAsync();
        Task<PetResponse> SaveAsync(Pet pet);
        Task<PetResponse> UpdateAsync(int id, Pet pet);
        Task<PetResponse> DeleteAsync(int id);
        Task<PetResponse> SaveByCustomerIdAsync(int customerId, Pet pet);
        Task<IEnumerable<Pet>> ListByCostumerIdAsync(int customerId);
        Task<PetResponse> FindByIdAsync(int petId);
        Task<Pet> FindPetByPersonId(int personId, int petId);
    }
}
