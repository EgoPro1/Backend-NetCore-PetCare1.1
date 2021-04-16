using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Persistence.Context;
using PetCare.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Repositories
{
    public class VaccinationRecordRepository:BaseRepository, IVaccinationRecordRepository
    {
        public VaccinationRecordRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsyn(VaccinationRecord vaccinationRecord)
        {
            await _context.VaccinationRecords.AddAsync(vaccinationRecord);
        }

        public async Task<VaccinationRecord> FindByIdAsync(int id)
        {
            return await _context.VaccinationRecords.FindAsync(id);
        }

        public async Task<IEnumerable<VaccinationRecord>> ListAsync()
        {
            return await _context.VaccinationRecords.ToListAsync();
        }

        public void Remove(VaccinationRecord vaccinationRecord)
        {
            //var profile =  _context.profiles.FindAsync(profileId);

            _context.VaccinationRecords.Remove(vaccinationRecord);
        }

        public void Update(VaccinationRecord vaccinationRecord)
        {
            _context.Update(vaccinationRecord);
        }


        public async Task SaveByProfileIdAsync(int profileId, VaccinationRecord VaccinationRecord)
        {
            var profile = await _context.MedicalProfiles.FindAsync(profileId);
            VaccinationRecord.Create_at = DateTime.Now;
            VaccinationRecord.ProfileId = profile.Id;
            await _context.VaccinationRecords.AddAsync(VaccinationRecord);
        }

        public async Task<IEnumerable<VaccinationRecord>> ListByProfileIdAsync(int profileId) =>
            await _context.VaccinationRecords
            .Where(p => p.ProfileId == profileId)
            .Include(p => p.Profile)
            .ToListAsync();



        /* public async Task<IEnumerable<ServicesProvider>> ListBySuscriptionPlanIdAsync(int planId) =>
            await _context.ServicesProviders
            .Where(p => p.SuscriptionPlanId == planId)
            .Include(p => p.SuscriptionPlan)
            .ToListAsync();
         */
    }
}

