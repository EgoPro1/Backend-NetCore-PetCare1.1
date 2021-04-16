using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> ListAsync();
        Task AddAsyn(Pet pet);
        Task<Pet> FindByIdAsync(int id);
        void Update(Pet pet);
        void Remove(Pet pet);
        Task SaveByCustomerIdAsync(int customerId, Pet pet);
        Task<IEnumerable<Pet>> ListByCustomerIdAsync(int customerId);
        Task<Pet> FindPetByPersonId(int personId,int petId);


    }
}
