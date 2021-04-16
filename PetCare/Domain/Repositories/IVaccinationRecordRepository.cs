using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
   public interface IVaccinationRecordRepository
    {
        Task<IEnumerable<VaccinationRecord>> ListAsync();
        Task AddAsyn(VaccinationRecord VaccinationRecord);
        Task<VaccinationRecord> FindByIdAsync(int id);
        void Update(VaccinationRecord VaccinationRecord);
        void Remove(VaccinationRecord VaccinationRecord);
        Task SaveByProfileIdAsync(int profileId, VaccinationRecord vaccinationRecord);
        Task<IEnumerable<VaccinationRecord>> ListByProfileIdAsync(int profileId);

    }
}
