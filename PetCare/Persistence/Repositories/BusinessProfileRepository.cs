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
    public class BusinessProfileRepository : BaseRepository, IBusinessProfileRepository
    {
        public BusinessProfileRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsyn(BusinessProfile businessProfile)
        {
            await _context.BusinessProfiles.AddAsync(businessProfile);
        }

        public async Task<PersonProfile> FindByIdAsync(int id)
        {
            //      return await _context.BusinessProfiles.FindAsync(id);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BusinessProfile>> ListFindByProviderId(int providerId) =>
            await _context.BusinessProfiles
            .Where(x => x.ProviderId == providerId && x.Owner == true )
            .Include(x => x.Provider)
            .ToListAsync();

        public async Task<BusinessProfile> FindByProviderId(int providerId) =>
            await _context.BusinessProfiles
            .Where(x => x.ProviderId == providerId && x.Owner == true)
            .Include(x => x.Provider)
            .FirstOrDefaultAsync();


        public async Task<IEnumerable<BusinessProfile>> ListAsync()
        {
            return await _context.BusinessProfiles.ToListAsync();
        }

        public void Remove(BusinessProfile businessProfile)
        {
            _context.BusinessProfiles.Remove(businessProfile);
        }

        public void Update(BusinessProfile businessProfile)
        {
            _context.Update(businessProfile);
        }


        /*public async Task AddAsyn(PersonProfile customer)
        {
            await _context.PersonProfiles.AddAsync(customer);
        }

        public async Task<PersonProfile> FindByIdAsync(int id)
        {
            return await _context.PersonProfiles.FindAsync(id);
        }

        public async Task<IEnumerable<PersonProfile>> ListAsync()
        {
            return await _context.PersonProfiles.ToListAsync();
        }

        public void Remove(PersonProfile customer)
        {
            _context.PersonProfiles.Remove(customer);
        }

        public void Update(PersonProfile customer)
        {
            _context.Update(customer);
        }*/
    }
}
