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
    public class AvailabilityService:IAvailabilityService
    {
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;


        public AvailabilityService(IAvailabilityRepository availabilityRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _availabilityRepository = availabilityRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }



        public async Task<IEnumerable<Availability>> ListAsync()
        {
            return await _availabilityRepository.ListAsync();
        }

        public async Task<AvailabilityResponse> SaveAsync(Availability availability)
        {
            try
            {
                await _availabilityRepository.AddAsyn(availability);
                await _unitOfWork.CompleteAsync();

                return new AvailabilityResponse(availability);
            }
            catch (Exception ex)
            {
                return new AvailabilityResponse($"An error ocurred while saving the Availability: {ex.Message}");
            }
        }

        public async Task<AvailabilityResponse> UpdateAsync(int id, Availability availability)
        {
            var existingavailability = await _availabilityRepository.FindByIdAsync(id);

            if (existingavailability == null)
                return new AvailabilityResponse(" availability not found");

            existingavailability.DayAvailability = availability.DayAvailability;
            existingavailability.StartTime = availability.DayAvailability;
            existingavailability.EndTime = availability.DayAvailability;

            try
            {
                _availabilityRepository.Update(existingavailability);
                await _unitOfWork.CompleteAsync();

                return new AvailabilityResponse(existingavailability);
            }
            catch (Exception ex)
            {
                return new AvailabilityResponse($"An error ocurred while updating the Availability: {ex.Message}");
            }
        }

        public async Task<AvailabilityResponse> DeleteAsync(int id)
        {
            var existingavailability = await _availabilityRepository.FindByIdAsync(id);

            if (existingavailability == null)
                return new AvailabilityResponse(" availability not found.");

            try
            {
                _availabilityRepository.Remove(existingavailability);
                await _unitOfWork.CompleteAsync();
                return new AvailabilityResponse(existingavailability);
            }
            catch (Exception ex)
            {
                return new AvailabilityResponse($"An error ocurred while deleting the Availability: {ex.Message}");
            }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Availability>> ListByProviderIdAndProductIdAsync(int providerId, int productId)
        {

            return await _availabilityRepository.ListByProductIdAsync(productId);
        }

        public async Task<AvailabilityResponse> SaveByProductIdAsync(int providerId, int productId, Availability availability)
        {
            var productDB = _productRepository.FindByIdAsync(productId);
            try
            {
                
                if (productDB != null)
                {
                    availability.Product = productDB.Result;
                    availability.ProductId = productId;
                    await _availabilityRepository.SaveByProductIdAsync(providerId, productId, availability);
                    await _unitOfWork.CompleteAsync();

                    return new AvailabilityResponse(availability);
                }


                return new AvailabilityResponse("Product not found");


            }
            catch (Exception ex)
            {
                return new AvailabilityResponse($"An error ocurred while saving th Availability: {ex.Message}");
            }

        }
    }
}
