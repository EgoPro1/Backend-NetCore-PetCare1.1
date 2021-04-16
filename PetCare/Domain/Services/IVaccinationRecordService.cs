using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IVaccinationRecordService
    {
        Task<IEnumerable<VaccinationRecord>> ListAsync();
        Task<VaccinationRecordResponse> SaveAsync(VaccinationRecord VaccinationRecord);
        Task<VaccinationRecordResponse> UpdateAsync(int id, VaccinationRecord vaccinationRecord);
        Task<VaccinationRecordResponse> DeleteAsync(int id);
        Task<VaccinationRecordResponse> SaveByProfileIdAsync(int profileId, VaccinationRecord vaccinationRecord);
        Task<IEnumerable<VaccinationRecord>> ListByProfileIdAsync(int customerId);

        Task<VaccinationRecordResponse> FindByIdAsync(int vaccinationRecordId);
    }
}
