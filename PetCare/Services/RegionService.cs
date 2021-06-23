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
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
   
        private readonly IUnitOfWork _unitOfWork;


        public RegionService(IRegionRepository RegionRepository, IUnitOfWork unitOfWork)
        {
            _regionRepository = RegionRepository;
      
            _unitOfWork = unitOfWork;
     
        }


        public async Task<RegionResponse> SaveAsync(Region region)
        {

            try
            {
                await _regionRepository.AddAsyn(region);
                await _unitOfWork.CompleteAsync();

                return new RegionResponse(region);
            }
            catch (Exception ex)
            {
                return new RegionResponse($"An error ocurred while saving the businessProfile: {ex.Message}");
            }
        }

        public async Task<RegionResponse> UpdateAsync(int id, Region region_o)
        {
            var existingCustomer = await _regionRepository.FindByRegionId(id);
                 await _unitOfWork.CompleteAsync();

            if (existingCustomer == null)
                return new RegionResponse("business not found");

             existingCustomer.region = region_o.region;
        


            try
            {
                _regionRepository.Update(existingCustomer);
                await _unitOfWork.CompleteAsync();

                return new RegionResponse(existingCustomer);
            }
            catch (Exception ex)
            {
                return new RegionResponse($"An error ocurred while updating the region: {ex.Message}");
            }
        }

        public async Task<RegionResponse> DeleteAsync(int id)
        {
            var existingbusiness = await _regionRepository.FindByRegionId(id);
         //   var existingprovider = await _regionRepository.FindByIdAsync(existingbusiness.ProviderId);
            if (existingbusiness == null)
                return new RegionResponse("regionnot found.");

            try
            {
                _regionRepository.Remove(existingbusiness);
              
                await _unitOfWork.CompleteAsync();
                return new RegionResponse(existingbusiness);
            }
            catch (Exception ex)
            {
                return new RegionResponse($"An error ocurred while deleting the customer: {ex.Message}");
            }
        }

        public async Task<Region> FindByRegionId(int id)
        {
            return await _regionRepository.FindByRegionId(id);
        }

        public async Task<IEnumerable<Region>> ListAsync()
        {
            return await _regionRepository.ListAsync();
        }

 
    }
}
