using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Services
{
    public class VaccinationRecordService: IVaccinationRecordService
    {
        private readonly IVaccinationRecordRepository _vaccinationRecordRepository;
        private readonly IUnitOfWork _unitOfWork;


        public VaccinationRecordService(IVaccinationRecordRepository vaccinationRecordRepository, IUnitOfWork unitOfWork)
        {
            _vaccinationRecordRepository = vaccinationRecordRepository;
            _unitOfWork = unitOfWork;
        }



        public async Task<IEnumerable<VaccinationRecord>> ListAsync()
        {
            return await _vaccinationRecordRepository.ListAsync();
        }

        public async Task<VaccinationRecordResponse> SaveAsync(VaccinationRecord vaccinationRecord)
        {
            try
            {
                await _vaccinationRecordRepository.AddAsyn(vaccinationRecord);
                await _unitOfWork.CompleteAsync();

                return new VaccinationRecordResponse(vaccinationRecord);
            }
            catch (Exception ex)
            {
                return new VaccinationRecordResponse($"An error ocurred while saving the pet: {ex.Message}");
            }
        }

        public async Task<VaccinationRecordResponse> UpdateAsync(int id, VaccinationRecord vaccinationRecord)
        {
            var existingvaccinationRecord = await _vaccinationRecordRepository.FindByIdAsync(id);

            if (existingvaccinationRecord == null)
                return new VaccinationRecordResponse("vaccinationRecord not found");

            existingvaccinationRecord.Name = vaccinationRecord.Name;
            existingvaccinationRecord.Description = vaccinationRecord.Description;
            //no creo que la fecha deba cambiarse
           // existingvaccinationRecord.Create_at = vaccinationRecord.Create_at;
            

            try
            {
                _vaccinationRecordRepository.Update(existingvaccinationRecord);
                await _unitOfWork.CompleteAsync();

                return new VaccinationRecordResponse(existingvaccinationRecord);
            }
            catch (Exception ex)
            {
                return new VaccinationRecordResponse($"An error ocurred while updating the pet: {ex.Message}");
            }
        }

        public async Task<VaccinationRecordResponse> DeleteAsync(int id)
        {
            var existingvaccinationRecord = await _vaccinationRecordRepository.FindByIdAsync(id);

            if (existingvaccinationRecord == null)
                return new VaccinationRecordResponse(" vaccinationRecord not found.");

            try
            {
                _vaccinationRecordRepository.Remove(existingvaccinationRecord);
                await _unitOfWork.CompleteAsync();
                return new VaccinationRecordResponse(existingvaccinationRecord);
            }
            catch (Exception ex)
            {
                return new VaccinationRecordResponse($"An error ocurred while deleting the vaccinationRecord: {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<VaccinationRecordResponse> SaveByProfileIdAsync(int profileId, VaccinationRecord vaccinationRecord)
        {
            try
            {
                await _vaccinationRecordRepository.SaveByProfileIdAsync(profileId, vaccinationRecord);
                await _unitOfWork.CompleteAsync();

                return new VaccinationRecordResponse(vaccinationRecord);
            }
            catch (Exception ex)
            {
                return new VaccinationRecordResponse($"An error ocurred while saving the pet: {ex.Message}");
            }

        }

        public async Task<IEnumerable<VaccinationRecord>> ListByProfileIdAsync(int profileId)
        {
            return await _vaccinationRecordRepository.ListByProfileIdAsync(profileId);
        }

        public async Task<VaccinationRecordResponse> FindByIdAsync(int vaccinationRecordId)
        {
            try
            {
                var vaccinationRecord = await _vaccinationRecordRepository.FindByIdAsync(vaccinationRecordId);
                var aux = new VaccinationRecordResponse(vaccinationRecord);
                if (vaccinationRecord == null)
                {
                    aux = new VaccinationRecordResponse(false, "No se encontro a la vaccinationRecord porque no existe", vaccinationRecord);

                }
                return aux;
                //var pet = await _petRepository.FindByIdAsync(petId);
                //      return new PetResponse(pet);
            }
            catch (Exception ex)
            {
                return new VaccinationRecordResponse($"An error ocurred while deleting the  vaccinationRecord: {ex.Message}");
            }
        }
    }
}
