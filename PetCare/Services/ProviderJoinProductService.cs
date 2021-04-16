using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Domain.Services;
using PetCare.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Services
{
    public class ProviderJoinProductService : IProviderJoinProductService
    {
        private readonly IProviderJoinProductRepository _providerJoinProductRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly ITypeProductRepository _typeProductRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProviderJoinProductService(IProviderJoinProductRepository providerJoinProductRepository, ITypeProductRepository typeProductRepository,
            IProviderRepository providerRepository, IUnitOfWork unitOfWork)
        {
            _providerJoinProductRepository = providerJoinProductRepository;
            _unitOfWork = unitOfWork;
            _typeProductRepository = typeProductRepository;
            _providerRepository = providerRepository;
        }

        public async  Task<ProviderJoinProductResponse> AssignProviderProduct(int providerId, int typeproductId)
        {
            try
            {
                var providerBD = _providerRepository.FindByIdAsync(providerId);
                var typeproductBD = _typeProductRepository.FindByIdAsync(typeproductId);

                ProviderJoinProduct providerJoinProduct = new ProviderJoinProduct();
               // providerJoinProduct.Provider = providerBD.Result;
                providerJoinProduct.ProviderId = providerId;
              //  providerJoinProduct.TypeProduct = typeproductBD.Result;
                providerJoinProduct.TypeProductId = typeproductId;

                await _providerJoinProductRepository.AssignProviderTypeProduct(providerJoinProduct);
                await _unitOfWork.CompleteAsync();

                return new ProviderJoinProductResponse(providerJoinProduct);
            }
            catch (Exception ex)
            {

                return new ProviderJoinProductResponse($"An error ocurred while assigning service to provider: {ex.Message}");
            }

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProviderJoinProduct>> ListByProviderIdAsync(int providerId)
        {
            return await _providerJoinProductRepository.ListProductTypeByProviderId(providerId);
      
        }


        /*  public async Task<ProviderJoinProductResponse> AssignProviderProduct(int providerId, int productId)
          {
             try
             {

                 await _providerJoinProductRepository.AssignProviderProduct(providerId, productId);
                 await _unitOfWork.CompleteAsync();
                 ProviderJoinProduct providerJoinService = await _providerJoinProductRepository.FindByProviderIdAndProductId(providerId, productId);
                 return new ProviderJoinProductResponse(providerJoinService);
             }
             catch (Exception ex)
             {
                 return new ProviderJoinProductResponse($"An error ocurred while assigning service to provider: {ex.Message}");
             }
          }


          public async Task<IEnumerable<Product>> ListByProviderIdAsync(int providerId)
          {
          // return await _providerJoinServiceRepository.ListByProviderIdAsync(providerId);
          var providerService = await _providerJoinProductRepository.ListByProviderIdAsync(providerId);
          var services = providerService.Select(ps => ps.Product).ToList();
          return services;
          }
          */

    }
}
