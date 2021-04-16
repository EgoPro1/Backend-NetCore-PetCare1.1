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
    public class ProductService : IProductService 
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResponse> FindById(int productId)
        {
            try
            {
                var productBD = _productRepository.FindByIdAsync(productId);
                return new ProductResponse(productBD.Result);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error ocurred the FindByproductId: {ex.Message}");
            }
        }

        public async Task<ProductResponse> findByName(string name)
        {
            try
            {
                var service = await _productRepository.FindByNameAsync(name);
                return new ProductResponse(service);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error ocurred the ServiceType: {ex.Message}");
            }
        }
         
        public async Task<IEnumerable<Product>> ListByTypeProductIdAsync(int providerId,int serviTypeId)
        {
            return await _productRepository.ListByTypeProductIdAsync(providerId,serviTypeId);
        }

        public async Task<ProductResponse> SaveByTypeProductIdAsync(int serviTypeId, Product service)
        {
            try
            {
                await _productRepository.SaveByTypeProductIdAsync(serviTypeId, service);
                await _unitOfWork.CompleteAsync();

                return new ProductResponse(service);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error ocurred while saving the ServiceType: {ex.Message}");
            }
        }
    }
}
