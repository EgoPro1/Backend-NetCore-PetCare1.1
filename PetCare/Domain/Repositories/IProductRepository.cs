using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IProductRepository
    {
        //Task<> FindByIdAsync(int serviceId);
        Task<Product> FindByNameAsync(string name);
        Task<Product> FindByIdAsync(int productId);
        Task SaveByTypeProductIdAsync(int typeProductId, Product product);
        Task<IEnumerable<Product>> ListByTypeProductIdAsync(int providerId,int typeProductId);
    }
}
