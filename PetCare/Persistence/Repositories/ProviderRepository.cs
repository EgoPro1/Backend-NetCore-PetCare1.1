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
    public class ProviderRepository : BaseRepository, IProviderRepository
    {
        public ProviderRepository(AppDbContext context) : base(context)
        { }

        public async Task AddAsyn(Provider servicesProvider)
        {
            await _context.Providers.AddAsync(servicesProvider);
        }

        public async Task<Provider> FindByIdAsync(int id)
        {
            return await _context.Providers.FindAsync(id);
        }

        public async Task<IEnumerable<Provider>> ListAsync()
        {
            return await _context.Providers.ToListAsync();
        }

        public Task<IEnumerable<Provider>> ListBySuscriptionPlanIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Provider>> ListByAddressAsync(string address) => 
            await _context.Providers
            .Where(p => p.Address == address)
            .ToListAsync();

        public void Remove(Provider servicesProvider)
        {
            _context.Providers.Remove(servicesProvider);
        }

        public void Update(Provider servicesProvider)
        {
            _context.Update(servicesProvider);

        }
        /*public async Task<IEnumerable<Provider>> ListBySuscriptionPlanIdAsync(int planId) =>
        await _context.ServicesProviders
          .Where(p => p.SuscriptionPlanId == planId)
          .Include(p => p.SuscriptionPlan)
          .ToListAsync();*/


    }
}
