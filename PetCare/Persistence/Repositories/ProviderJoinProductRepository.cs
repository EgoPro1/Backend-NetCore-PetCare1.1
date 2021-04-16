using Microsoft.CodeAnalysis.FlowAnalysis;
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
    public class ProviderJoinProductRepository : BaseRepository, IProviderJoinProductRepository
    {
        public ProviderJoinProductRepository(AppDbContext context) : base(context) { }

        public async Task AssignProviderTypeProduct(ProviderJoinProduct providerJoinProduct)
        {
               await _context.ProviderJoinProducts.AddAsync(providerJoinProduct);
        }

        public Task<ProviderJoinProduct> FindByProviderIdAndProductId(int providerId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProviderJoinProduct>> ListByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProviderJoinProduct>> ListByProviderIdAsync(int providerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProviderJoinProduct>> ListProductTypeByProviderId(int providerId) =>
            await _context.ProviderJoinProducts
            .Where(x => x.ProviderId == providerId)
            .Include(x => x.TypeProduct)
            .ToListAsync();



        /*    var person = (from p in _context.ProviderJoinProducts
                          join pt in _context.TypeProducts
                          on p.TypeProductId equals pt.Id
                          where p.TypeProductId == pt.Id
                          
                          ).ToList();

            return person;*/

        /* 
         */


        /*  public async Task AssignProviderProduct(int providerId, int productId)
          {
              ProviderJoinProduct providerJoinProduct = await FindByProviderIdAndProductId(providerId, productId);
              if (providerJoinProduct == null)
              {
                   providerJoinProduct = new ProviderJoinProduct { ProviderId = providerId, ProductId = productId };
                  await _context.ProviderJoinProducts.AddAsync(providerJoinProduct);
              }
          }

           public async Task<ProviderJoinProduct> FindByProviderIdAndProductId(int providerId, int productId)
           {
               return await _context.ProviderJoinProducts.FindAsync(providerId, productId);
           }

           public async Task<IEnumerable<ProviderJoinProduct>> ListByProviderIdAsync(int providerId)
            {
                return await _context.ProviderJoinProducts
                   .Where(ps => ps.ProviderId == providerId)
                   .Include(ps => ps.Provider)
                   .Include(ps => ps.Product)
                   .ToListAsync();
            }

            public async Task<IEnumerable<ProviderJoinProduct>> ListByProductIdAsync(int providerId)
            {
                return await _context.ProviderJoinProducts
                   .Where(ps => ps.ProductId == providerId)
                   .Include(ps => ps.Provider)
                   .Include(ps => ps.Product)
                   .ToListAsync();
            }*/
    }
}
