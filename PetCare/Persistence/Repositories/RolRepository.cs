using PetCare.Domain.Models;
using PetCare.Persistence.Context;
using PetCare.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public class RolRepository : BaseRepository, IRolRepository
    {
        public RolRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsyn(Rol rol)
        {
            await _context.Roles.AddAsync(rol);
        }

        public async Task<Rol> FindByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

    }
}
