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
    public class AvailabilityRepository : BaseRepository, IAvailabilityRepository
    {
       public AvailabilityRepository(AppDbContext context) : base(context)
        {

        }

        public Task AddAsyn(Availability availability)
        {
            throw new NotImplementedException();
        }

        public Task<Availability> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Availability>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Availability>> ListByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Availability availability)
        {
            throw new NotImplementedException();
        }

        public async Task SaveByProductIdAsync(int providerId, int productId, Availability availability)
        {
            //var provider = await _context.Providers.FindAsync(providerId);
            //var provider_join_products = await _context.ProviderJoinProducts.FindAsync(providerId, productId);
            //availability.ProviderId = provider_join_products.ProviderId;
            //availability.ProductId= provider_join_products.TypeProductId;
            await _context.Availabilities.AddAsync(availability);
        }

        public void Update(Availability availability)
        {
            throw new NotImplementedException();
        }
        /*
       public async Task AddAsyn(Availability availability)
       {
           await _context.Availabilities.AddAsync(availability);
       }

       public async Task<Availability> FindByIdAsync(int id)
       {
           return await _context.Availabilities.FindAsync(id);
       }

       public async Task<IEnumerable<Availability>> ListAsync()
       {
           return await _context.Availabilities.ToListAsync();
       }

       public async Task<IEnumerable<Availability>> ListByProductIdAsync(int productId) =>
           await _context.Availabilities
           .Where(p => p.ProductId == productId)
           .Include(p => p.Product)
           .ToListAsync();

       public void Remove(Availability availability)
       {
           _context.Availabilities.Remove(availability);
       }

       public async Task SaveByProductIdAsync(int providerId, int productId, Availability availability)
       {
           var provider = await _context.ProductProviders.FindAsync(providerId);
           var provider_join_products = await _context.ProviderJoinProducts.FindAsync(providerId, productId);
           availability.ProviderId = provider_join_products.ProviderId;
           availability.ProductId= provider_join_products.ProductId;
           await _context.Availabilities.AddAsync(availability);
       }

       public void Update(Availability availability)
       {
           _context.Update(availability);
       }*/
    }
}
