using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IProductService
    {
        Task<ProductResponse> findByName(string name);
        Task<ProductResponse> SaveByTypeProductIdAsync(int typeProductId, Product product);
        Task<IEnumerable<Product>> ListByTypeProductIdAsync(int providerId, int typeProductId);
        Task<ProductResponse> FindById(int productId);
    }
}
