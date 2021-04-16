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
    public class SuscriptionPlanService : ISuscriptionPlanService
    {
        private readonly ISuscriptionPlanRepository _suscriptionPlanRepository;
        private readonly IUnitOfWork _unitOfWork;


        public SuscriptionPlanService(ISuscriptionPlanRepository suscriptionPlanRepository, IUnitOfWork unitOfWork)
        {
            _suscriptionPlanRepository = suscriptionPlanRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SubscriptionPlan>> ListAsync()
        {
            return await _suscriptionPlanRepository.ListAsync();
        }

        public async Task<SuscriptionPlanResponse> SaveAsync(SubscriptionPlan suscriptionPlan)
        {
            try
            {
                await _suscriptionPlanRepository.AddAsyn(suscriptionPlan);
                await _unitOfWork.CompleteAsync();

                return new SuscriptionPlanResponse(suscriptionPlan);
            }
            catch (Exception ex)
            {
                return new SuscriptionPlanResponse($"An error ocurred while saving the SuscriptionPlan: {ex.Message}");
            }
        }

        public async Task<SuscriptionPlanResponse> UpdateAsync(int id, SubscriptionPlan suscriptionPlan)
        {
            var existingSuscriptionPlan = await _suscriptionPlanRepository.FindByIdAsync(id);

            if (existingSuscriptionPlan == null)
                return new SuscriptionPlanResponse("SuscriptionPlan not found");

            existingSuscriptionPlan.Name = suscriptionPlan.Name;
            existingSuscriptionPlan.Price = suscriptionPlan.Price;
            existingSuscriptionPlan.Description = suscriptionPlan.Description;
            existingSuscriptionPlan.Duration = suscriptionPlan.Duration;



            try
            {
                _suscriptionPlanRepository.Update(existingSuscriptionPlan);
                await _unitOfWork.CompleteAsync();

                return new SuscriptionPlanResponse(existingSuscriptionPlan);
            }
            catch (Exception ex)
            {
                return new SuscriptionPlanResponse($"An error ocurred while updating the SuscriptionPlan: {ex.Message}");
            }
        }
       
        public async Task<SuscriptionPlanResponse> DeleteAsync(int id)
        {
            var existingSuscriptionPlan = await _suscriptionPlanRepository.FindByIdAsync(id);

            if (existingSuscriptionPlan == null)
                return new SuscriptionPlanResponse("SuscriptionPlan not found.");

            try
            {
                _suscriptionPlanRepository.Remove(existingSuscriptionPlan);
                await _unitOfWork.CompleteAsync();
                return new SuscriptionPlanResponse(existingSuscriptionPlan);
            }
            catch (Exception ex)
            {
                return new SuscriptionPlanResponse($"An error ocurred while deleting the SuscriptionPlan: {ex.Message}");
            }
            
        }

        public async Task<SuscriptionPlanResponse> GetById(int id)
        {
            var suscriptionDB = await _suscriptionPlanRepository.FindByIdAsync(id);
            return new SuscriptionPlanResponse(suscriptionDB);
        }
    }
}
