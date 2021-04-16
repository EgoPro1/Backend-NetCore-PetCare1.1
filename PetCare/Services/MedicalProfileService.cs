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
    public class MedicalProfileService : IMedicalProfileService
    {
        private readonly IMedicalProfileRepository _medicalprofileRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPetRepository _petRepository;
        private readonly IProviderRepository _providerRepository;
      //  private readonly ICustomerRepository _customerRepository;


        public MedicalProfileService(IMedicalProfileRepository medicalprofileRepository, IPetRepository petRepository, IProviderRepository providerRepository,IUnitOfWork unitOfWork)
        {
            _medicalprofileRepository = medicalprofileRepository;
            _unitOfWork = unitOfWork;
            _petRepository = petRepository;
            _providerRepository = providerRepository;
        }



        public async Task<IEnumerable<MedicalProfile>> ListAsync()
        {
            return await _medicalprofileRepository.ListAsync();
        }

        public async Task<MedicalProfileResponse> SaveAsync(MedicalProfile medicalprofile)
        {
            try
            {
                await _medicalprofileRepository.AddAsyn(medicalprofile);
                await _unitOfWork.CompleteAsync();

                return new MedicalProfileResponse(medicalprofile);
            }
            catch (Exception ex)
            {
                return new MedicalProfileResponse($"An error ocurred while saving the medicalprofile: {ex.Message}");
            }
        }

        public async Task<MedicalProfileResponse> UpdateAsync(int id, MedicalProfile  medicalprofile)
        {
            var existingmedicalprofile = await _medicalprofileRepository.FindByIdAsync(id);

            if (existingmedicalprofile == null)
                return new MedicalProfileResponse(" medicalprofile not found");

            existingmedicalprofile.Name =  medicalprofile.Name;
            existingmedicalprofile.Weight =  medicalprofile.Weight;
            existingmedicalprofile.Lenght =  medicalprofile.Lenght;
            existingmedicalprofile.Eyes =  medicalprofile.Eyes;
            existingmedicalprofile.Breed =  medicalprofile.Breed; 
            existingmedicalprofile.Sex =  medicalprofile.Sex;
            existingmedicalprofile.Color =  medicalprofile.Color;
            existingmedicalprofile.Description =  medicalprofile.Description;
            existingmedicalprofile.Photo =  medicalprofile.Photo;
            existingmedicalprofile.Age =  medicalprofile.Age;
      
            try
            {
                _medicalprofileRepository.Update(existingmedicalprofile);
                await _unitOfWork.CompleteAsync();

                return new MedicalProfileResponse(existingmedicalprofile);
            }
            catch (Exception ex)
            {
                return new MedicalProfileResponse($"An error ocurred while updating the medicalprofile: {ex.Message}");
            }
        }

        public async Task<MedicalProfileResponse> DeleteAsync(int id)
        {
            var existingmedicalprofile = await _medicalprofileRepository.FindByIdAsync(id);

            if (existingmedicalprofile == null)
                return new MedicalProfileResponse(" medicalprofile not found.");

            try
            {
                _medicalprofileRepository.Remove(existingmedicalprofile);
                await _unitOfWork.CompleteAsync();
                return new MedicalProfileResponse(existingmedicalprofile);
            }
            catch (Exception ex)
            {
                return new MedicalProfileResponse($"An error ocurred while deleting the MedicalProfile: {ex.Message}");
            }
            throw new NotImplementedException();
        }

     /*   public async Task<MedicalProfileResponse> SaveByPetIdAsync(int petId, MedicalProfile medicalprofile)
        {
            try
            {
                await _medicalprofileRepository.SaveByPetIdAsync(petId, medicalprofile);
                await _unitOfWork.CompleteAsync();

                return new MedicalProfileResponse(medicalprofile);
            }
            catch (Exception ex)
            {
                return new MedicalProfileResponse($"An error ocurred while saving th medicalprofile: {ex.Message}");
            }

        }*/

        public async Task<IEnumerable<MedicalProfile>> ListByCustomerIdAndPetIdAsync(int customerId,int petId)
        {
            //var customer = _customerRepository.FindByIdAsync(customerId);
           /* if (customer !=null)
            {
                return new MedicalProfileResponse("Not Found customer");
                
            }*/
            return await _medicalprofileRepository.ListByPetIdAsync(petId);
        }

        public async Task<MedicalProfileResponse> SaveByPetIdAsync(int providerId, int customerId, int petId, MedicalProfile medicalprofile)
        {
           /* var customer = _customerRepository.FindByIdAsync(customerId);
            if ( customer==null )
            {
                return new MedicalProfileResponse("Not Found customer");
            }
            */
            
           
            try
            {
                var petDB = _petRepository.FindByIdAsync(petId);
                var providerDB = _providerRepository.FindByIdAsync(providerId);
                medicalprofile.Pet = petDB.Result;
                medicalprofile.PetId = petId;
                medicalprofile.Provider = providerDB.Result;
                medicalprofile.ProviderId = providerId;
               
                await _medicalprofileRepository.AddAsyn(medicalprofile);
                await _unitOfWork.CompleteAsync();

                return new MedicalProfileResponse(medicalprofile);
            }
            catch (Exception ex)
            {
                return new MedicalProfileResponse($"An error ocurred while saving th medicalprofile: {ex.Message}");
            }

        }


        public async Task<MedicalProfileResponse> FindByIdAsync(int profileId)
        {
            try
            {
                var profile = await _medicalprofileRepository.FindByIdAsync(profileId);
                var aux = new MedicalProfileResponse(profile);
                if (profile == null)
                {
                    aux = new MedicalProfileResponse(false, "No se encontro al profile porque no existe", profile);

                }
                return aux;
                //var pet = await _petRepository.FindByIdAsync(petId);
                //      return new PetResponse(pet);
            }
            catch (Exception ex)
            {
                return new MedicalProfileResponse($"An error ocurred while deleting the pet: {ex.Message}");
            }
        }

        public async Task<IEnumerable<MedicalProfile>> ListByPetIdAsync(int petId)
        {
            return await _medicalprofileRepository.ListByPetIdAsync(petId);
        }

       
    }
}
