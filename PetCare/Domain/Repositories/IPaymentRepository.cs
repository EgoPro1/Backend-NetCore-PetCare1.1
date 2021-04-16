using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> ListAsync();
        Task AddAsyn(Payment Payment);
        Task<Payment> FindByIdAsync(int id);
        void Update(Payment Payment);
        void Remove(Payment Payment);

        Task SaveByServicesProviderIdAsync(int sproviderId, Payment payment);
        Task<IEnumerable<Payment>> ListByServicesProviderIdAsync(int sproviderId);
    }
}
