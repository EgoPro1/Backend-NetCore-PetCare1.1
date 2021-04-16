using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IRequestService
    {
        Task<RequestResponse> SaveByCustomerIdAsync(int customerId, int providerId,int productTypeId, int productId, int petId, PersonRequest Request);
        Task<IEnumerable<PersonRequest>> ListByCostumerIdAsync(int customerId);
        Task<IEnumerable<PersonRequest>> ListByProductIdAsync(int providerId);
        //Task<PersonRequest> Update(int requestId, PersonRequest personRequest);
    }
}
