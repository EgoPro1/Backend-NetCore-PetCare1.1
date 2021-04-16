using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace PetCare.Persistence.Repositories
{
    public class TypeProductRepository : BaseRepository, ITypeProductRepository
    {
        public TypeProductRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsyn(TypeProduct serviType)
        {
             await _context.TypeProducts.AddAsync(serviType);
        }

        public async Task<TypeProduct> FindByIdAsync(int id)
        {
            return await _context.TypeProducts.FindAsync(id);
        }

        public async Task<IEnumerable<TypeProduct>> ListAsync()
        {
            return await _context.TypeProducts.ToListAsync();
        }


        public async Task<TypeProduct> FindByName(string name) =>
            await _context.TypeProducts
            .Where(w => w.Name == name)
            .FirstOrDefaultAsync();

    }
}
