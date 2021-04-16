using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IMedicalRecordRepository
    {

        Task AddAsync( MedicalRecord medicalRecord);
        Task<IEnumerable<MedicalRecord>> ListByMedicalProfile(int profileId);

    }
}
