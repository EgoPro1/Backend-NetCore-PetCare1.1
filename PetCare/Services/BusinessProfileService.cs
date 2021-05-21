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
    public class BusinessProfileService : IBusinessProfileService
    {
        private readonly IBusinessProfileRepository _businessRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IRolRepository _rolRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IUnitOfWork _unitOfWork;


        public BusinessProfileService(IBusinessProfileRepository businessRepository, IAccountRepository accountRepository,
            IRolRepository rolRepository, IProviderRepository providerRepository, IUnitOfWork unitOfWork)
        {
            _businessRepository = businessRepository;
            _accountRepository = accountRepository;
            _providerRepository = providerRepository;
            _unitOfWork = unitOfWork;
            _rolRepository = rolRepository;
        }


        public async Task<BusinessProfileResponse> SaveAsync(BusinessProfile businessProfile)
        {
            Account account = new Account();
            account.User = businessProfile.Email;
            account.Password = businessProfile.Password;
            account.RolId = 1;
            account.SubscriptionPlanId = 1; // Por defecto tiene el plan free
            account.BusinessProfile = businessProfile;
            account.Rol = _rolRepository.FindByIdAsync(2).Result;

            try
            {
                if (businessProfile.Owner) // si eres propietario
                {
                    Provider provider = new Provider();
                    provider.BusinessName = "";
                    provider.Address= "";
                    provider.Description = "";
                    provider.Email = "";
                    provider.Field = "";
                    provider.Region = "";

                    await _providerRepository.AddAsyn(provider);

                    businessProfile.Provider = provider;
                    businessProfile.ProviderId = provider.Id;
                }
              
                await _businessRepository.AddAsyn(businessProfile);
                await _accountRepository.AddAsyn(account);
                await _unitOfWork.CompleteAsync();

                return new BusinessProfileResponse(businessProfile);
            }
            catch (Exception ex)
            {
                return new BusinessProfileResponse($"An error ocurred while saving the businessProfile: {ex.Message}");
            }
        }

        public async Task<BusinessProfileResponse> UpdateAsync(int id, BusinessProfile businessProfile)
        {
            var existingCustomer = await _businessRepository.FindByBusinessId(id);

            if (existingCustomer == null)
                return new BusinessProfileResponse("business not found");

            existingCustomer.Name = businessProfile.Name;
            existingCustomer.LastName = businessProfile.LastName;
            existingCustomer.Phone = businessProfile.Phone;
            existingCustomer.Age = businessProfile.Age;
            existingCustomer.Email = businessProfile.Email;
            existingCustomer.Document = businessProfile.Document;
            existingCustomer.Photo = businessProfile.Photo;


            try
            {

                _businessRepository.Update(existingCustomer);
                await _unitOfWork.CompleteAsync();

                return new BusinessProfileResponse(existingCustomer);
            }
            catch (Exception ex)
            {
                return new BusinessProfileResponse($"An error ocurred while updating the customer: {ex.Message}");
            }
        }

        public async Task<BusinessProfileResponse> DeleteAsync(int id)
        {
            var existingbusiness= await _businessRepository.FindByBusinessId(id);
            var existingprovider = await _providerRepository.FindByIdAsync(existingbusiness.ProviderId);
            if (existingbusiness== null)
                return new BusinessProfileResponse("customer not found.");

            try
            {
                _businessRepository.Remove(existingbusiness);
                _providerRepository.Remove(existingprovider);
                await _unitOfWork.CompleteAsync();
                return new BusinessProfileResponse(existingbusiness);
            }
            catch (Exception ex)
            {
                return new BusinessProfileResponse($"An error ocurred while deleting the customer: {ex.Message}");
            }
        }

        public Task<BusinessProfileResponse> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BusinessProfile>> ListAsync()
        {
            return await _businessRepository.ListAsync();
        }

        public async Task<IEnumerable<BusinessProfile>> ListFindByProviderId(int providerId)
        {
            return await _businessRepository.ListFindByProviderId(providerId);
        }

        public async Task<BusinessProfile> FindByBusinessId(int providerId)
        {
            return await _businessRepository.FindByBusinessId(providerId);
        }
    }
}
