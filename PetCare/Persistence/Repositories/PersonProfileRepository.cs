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
    public class PersonProfileRepository : BaseRepository, IPersonProfileRepository
    {
        public PersonProfileRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsyn(PersonProfile customer)
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
        }
    }
}
