using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IRequestRepository
    {
        Task SaveByCustomerIdAsync(PersonRequest request);
        Task<IEnumerable<PersonRequest>> ListByCustomerIdAsync(int customerId);
        Task<IEnumerable<PersonRequest>> ListByProductIdAsync(int serviceId);
        Task<PersonRequest> FindById(int requestId);
        void Update( PersonRequest personRequest);
    }
}
