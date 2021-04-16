using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IRolRepository
    {
        Task AddAsyn(Rol rol);
        Task<Rol> FindByIdAsync(int id);
    }
}
