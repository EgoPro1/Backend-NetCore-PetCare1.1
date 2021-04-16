using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> ListAsync();
        Task<PaymentResponse> SaveAsync(Payment Payment);
        Task<PaymentResponse> UpdateAsync(int id, Payment Payment);
        Task<PaymentResponse> DeleteAsync(int id);

        Task<PaymentResponse> SaveByServicesProviderIdAsync(int sproviderId, Payment payment);
        Task<IEnumerable<Payment>> ListByServicesProviderIdAsync(int sproviderId);
    }
}