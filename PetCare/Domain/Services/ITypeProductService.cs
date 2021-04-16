using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface ITypeProductService
    {
        Task<IEnumerable<TypeProduct>> ListAsync();
        Task<TypeProductResponse> SaveAsync(TypeProduct serviType);
        //Task<CustomerResponse> UpdateAsync(int id, Customer customer);
        //Task<CustomerResponse> DeleteAsync(int id);
        Task<TypeProductResponse> FindByIdAsync(int id);
    }
}
