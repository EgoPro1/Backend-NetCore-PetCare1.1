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
    public class MedicalRecordRepository : BaseRepository, IMedicalRecordRepository
    {
        public MedicalRecordRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<MedicalRecord>> ListByMedicalProfile(int profileId) =>
            await _context.MedicalRecords
            .Where(mr => mr.MedicalProfileId == profileId)
            .Include(mr => mr.MedicalProfile)
            .ToListAsync();

        public async Task AddAsync( MedicalRecord medicalRecord)
        {
    
            await _context.MedicalRecords.AddAsync(medicalRecord);
        }
    }
}
