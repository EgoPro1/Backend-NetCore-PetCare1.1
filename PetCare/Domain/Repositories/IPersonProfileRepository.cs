using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IPersonProfileRepository
    {
        Task<IEnumerable<PersonProfile>> ListAsync();
        Task AddAsyn(PersonProfile customer);
        Task<PersonProfile> FindByIdAsync(int id);
        void Update(PersonProfile customer);
        void Remove(PersonProfile customer);
    }
}
