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
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;


        public PetService(IPetRepository petRepository, IUnitOfWork unitOfWork)
        {
            _petRepository = petRepository;
            _unitOfWork = unitOfWork;
        }



        public async Task<IEnumerable<Pet>> ListAsync()
        {
            return await _petRepository.ListAsync();
        }

        public async Task<PetResponse> SaveAsync(Pet pet)
        {
            try
            {
                await _petRepository.AddAsyn(pet);
                await _unitOfWork.CompleteAsync();

                return new PetResponse(pet);
            }
            catch (Exception ex)
            {
                return new PetResponse($"An error ocurred while saving the pet: {ex.Message}");
            }
        }

        public async Task<PetResponse> UpdateAsync(int id, Pet pet)
        {
            var existingpet = await _petRepository.FindByIdAsync(id);

            if (existingpet == null)
                return new PetResponse("pet not found");

            existingpet.Name = pet.Name;
            existingpet.Age = pet.Age;
            existingpet.Breed = pet.Breed;
            existingpet.Photo = pet.Photo;
            existingpet.Sex = pet.Sex;

            try
            {
                _petRepository.Update(existingpet);
                await _unitOfWork.CompleteAsync();

                return new PetResponse(existingpet);
            }
            catch (Exception ex)
            {
                return new PetResponse($"An error ocurred while updating the pet: {ex.Message}");
            }
        }

        public async Task<PetResponse> DeleteAsync(int id)
        {
            var existingpet = await _petRepository.FindByIdAsync(id);

            if (existingpet == null)
                return new PetResponse("pet not found.");

            try
            {
                _petRepository.Remove(existingpet);
                await _unitOfWork.CompleteAsync();
                return new PetResponse(existingpet);
            }
            catch (Exception ex)
            {
                return new PetResponse($"An error ocurred while deleting the pet: {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<PetResponse> SaveByCustomerIdAsync(int customerId, Pet pet)
        {
            try
            {
                await _petRepository.SaveByCustomerIdAsync(customerId,pet);
                await _unitOfWork.CompleteAsync();

                return new PetResponse(pet);
            }
            catch (Exception ex)
            {
                return new PetResponse($"An error ocurred while saving the pet: {ex.Message}");
            }

        }

        public async Task<IEnumerable<Pet>> ListByCostumerIdAsync(int customerId)
        {
            return await _petRepository.ListByCustomerIdAsync(customerId);
        }



        public async Task<PetResponse> FindByIdAsync(int petId)
        {
            try
            {
                var pet = await _petRepository.FindByIdAsync(petId);
                var aux = new PetResponse(pet);
                if (pet == null)
                {
                    aux = new PetResponse(false, "No se encontro a la mascota porque no existe", pet);

                }
                return aux;
                //var pet = await _petRepository.FindByIdAsync(petId);
                //      return new PetResponse(pet);
            }
            catch (Exception ex)
            {
                return new PetResponse($"An error ocurred while deleting the pet: {ex.Message}");
            }
        }

        public async Task<Pet> FindPetByPersonId(int personId, int petId)
        {
            return await _petRepository.FindPetByPersonId(personId, petId);
        }
    }
}
