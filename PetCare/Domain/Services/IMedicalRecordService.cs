using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IMedicalRecordService
    {
        Task<MedicalRecordResponse> SaveByProfileIdAsync(int profileId, MedicalRecord medicalRecord);
        Task<IEnumerable<MedicalRecord>> ListByProfileIdAsync(int profileId);
    }
}
