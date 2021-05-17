using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Domain.Services;
using PetCare.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        private readonly IMedicalProfileRepository _medicalProfileRepository;
        private readonly IUnitOfWork _unitOfWork;


        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository, IMedicalProfileRepository medicalProfileRepository,  IUnitOfWork unitOfWork)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _medicalProfileRepository = medicalProfileRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<MedicalRecord>> ListByProfileIdAsync(int profileId)
        {
            return await _medicalRecordRepository.ListByMedicalProfile(profileId);
        }

        public async Task<MedicalRecordResponse> SaveByProfileIdAsync(int profileId, MedicalRecord medicalRecord)
        {
            try
            {
                var medicalProfileDB = _medicalProfileRepository.FindByIdAsync(profileId);
                medicalRecord.MedicalProfile = medicalProfileDB.Result;
                medicalRecord.MedicalProfileId = profileId;

                await _medicalRecordRepository.AddAsync( medicalRecord);
                await _unitOfWork.CompleteAsync();

                return new MedicalRecordResponse(medicalRecord);
            }
            catch (Exception ex)
            {
                return new MedicalRecordResponse($"An error ocurred while saving the medicalRecord: {ex.Message}");
            }
        }

      
    }
}
