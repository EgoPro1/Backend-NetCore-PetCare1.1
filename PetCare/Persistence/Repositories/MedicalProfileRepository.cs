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
    public class MedicalProfileRepository : BaseRepository, IMedicalProfileRepository
    {
        public MedicalProfileRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsyn(MedicalProfile medicalprofile)
        {
            await _context.MedicalProfiles.AddAsync(medicalprofile);
        }

        public async Task<MedicalProfile> FindByIdAsync(int id)
        {
            return await _context.MedicalProfiles.FindAsync(id);
        }

        public async Task<IEnumerable<MedicalProfile>> ListAsync()
        {
            return await _context.MedicalProfiles.ToListAsync();
        }

        public void Remove( MedicalProfile medicalprofile)
        {
            //var pet =  _context.Pets.FindAsync(petId);

            _context.MedicalProfiles.Remove(medicalprofile);
        }

        public void Update(MedicalProfile medicalprofile)
        {
            _context.Update(medicalprofile);
        }


      

        public async Task<IEnumerable<MedicalProfile>> ListByPetIdAsync(int petId) =>
            await _context.MedicalProfiles
            .Where(p => p.PetId == petId)
            .Include(p => p.Pet)
            .ToListAsync();



        /* public async Task<IEnumerable<ServicesProvider>> ListBySuscriptionPlanIdAsync(int planId) =>
            await _context.ServicesProviders
            .Where(p => p.SuscriptionPlanId == planId)
            .Include(p => p.SuscriptionPlan)
            .ToListAsync();
         */
    }
}
