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
    public class PetRepository : BaseRepository, IPetRepository
    {
        public PetRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsyn(Pet pet)
        {
            await _context.Pets.AddAsync(pet);
        }

        public async Task<Pet> FindByIdAsync(int id)
        {
            return await _context.Pets.FindAsync(id);
        }

        public async Task<IEnumerable<Pet>> ListAsync()
        {
            return await _context.Pets.ToListAsync();
        }

        public void Remove( Pet pet)
        {
            //var customer =  _context.PersonProfiles.FindAsync(customerId);
   
            _context.Pets.Remove(pet);
        }

        public void Update(Pet pet)
        {
            _context.Update(pet);
        }


        public async Task SaveByCustomerIdAsync(int customerId,Pet pet)
        {
            var customer =await _context.PersonProfiles.FindAsync(customerId);
            pet.PersonProfileId = customer.Id;
            await _context.Pets.AddAsync(pet); 
        }

        public async Task<IEnumerable<Pet>> ListByCustomerIdAsync(int customerId) =>
            await _context.Pets
            .Where(p => p.PersonProfileId == customerId)
            .Include(p => p.PersonProfile)
            .ToListAsync();

        public async Task<Pet> FindPetByPersonId(int personId, int petId) =>
            await _context.Pets
            .Where(x => x.PersonProfileId == personId && x.Id == petId)
            .Include(x => x.PersonProfile)
            .FirstOrDefaultAsync();



        /* public async Task<IEnumerable<ServicesProvider>> ListBySuscriptionPlanIdAsync(int planId) =>
            await _context.ServicesProviders
            .Where(p => p.SuscriptionPlanId == planId)
            .Include(p => p.SuscriptionPlan)
            .ToListAsync();
         */
    }
}
