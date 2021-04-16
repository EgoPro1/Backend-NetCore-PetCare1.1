using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Domain.Services;
using PetCare.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _PaymentRepository;
        private readonly IUnitOfWork _unitOfWork;


        public PaymentService(IPaymentRepository PaymentRepository, IUnitOfWork unitOfWork)
        {
            _PaymentRepository = PaymentRepository;
            _unitOfWork = unitOfWork;

        }



        public async Task<IEnumerable<Payment>> ListAsync()
        {
            return await _PaymentRepository.ListAsync();
        }

        public async Task<PaymentResponse> SaveAsync(Payment Payment)
        {
            try
            {
                await _PaymentRepository.AddAsyn(Payment);
                await _unitOfWork.CompleteAsync();

                return new PaymentResponse(Payment);
            }
            catch (Exception ex)
            {
                return new PaymentResponse($"An error ocurred while saving the Payment: {ex.Message}");
            }
        }

        public async Task<PaymentResponse> UpdateAsync(int id, Payment Payment)
        {

            var existingPayment = await _PaymentRepository.FindByIdAsync(id); ;

            if (existingPayment == null)
                return new PaymentResponse("Payment not found");

            existingPayment.Number = Payment.Number;
            existingPayment.Name = Payment.Name;
            existingPayment.CVV = Payment.CVV;
            existingPayment.DateOfExpiry = Payment.DateOfExpiry;

            try
            {
                _PaymentRepository.Update(existingPayment);
                await _unitOfWork.CompleteAsync();

                return new PaymentResponse(existingPayment);
            }
            catch (Exception ex)
            {
                return new PaymentResponse($"An error ocurred while updating the Payment: {ex.Message}");
            }
        }

        public async Task<PaymentResponse> DeleteAsync(int id)
        {
            var existingPayment = await _PaymentRepository.FindByIdAsync(id);

            if (existingPayment == null)
                return new PaymentResponse("Payment not found.");

            try
            {
                _PaymentRepository.Remove(existingPayment);
                await _unitOfWork.CompleteAsync();
                return new PaymentResponse(existingPayment);
            }
            catch (Exception ex)
            {
                return new PaymentResponse($"An error ocurred while deleting the Payment: {ex.Message}");
            }

        }

        public async Task<PaymentResponse> SaveByServicesProviderIdAsync(int sproviderId, Payment Payment)
        {
            try
            {
                await _PaymentRepository.SaveByServicesProviderIdAsync(sproviderId, Payment);
                await _unitOfWork.CompleteAsync();

                return new PaymentResponse(Payment);
            }
            catch (Exception ex)
            {
                return new PaymentResponse($"An error ocurred while saving the Payment: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Payment>> ListByServicesProviderIdAsync(int providerId)
        {
            return await _PaymentRepository.ListByServicesProviderIdAsync(providerId);

        }

        /* Task<IEnumerable<PaymentResponse>> IPaymentService.ListByServicesProviderIdAsync(int sproviderId)
         {
             throw new NotImplementedException();
         }*/
    }
}