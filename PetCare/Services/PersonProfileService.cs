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
    public class PersonProfileService : IPersonProfileService
    {
        private readonly IPersonProfileRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IRolRepository _rolRepository;
        private readonly IUnitOfWork _unitOfWork;


        public PersonProfileService(IPersonProfileRepository customerRepository, IAccountRepository accountRepository,
            IRolRepository rolRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
            _rolRepository = rolRepository;
        }

        public async Task<IEnumerable<PersonProfile>> ListAsync()
        {
            return await _customerRepository.ListAsync();
        }

        public async Task<PersonProfileResponse> SaveAsync(PersonProfile customer)
        {
            Account account = new Account();
            account.User = customer.Email;
            account.Password = customer.Password;
            account.RolId = 1;
            account.SubscriptionPlanId = 1; // Por defecto tiene el plan free
            account.PersonProfile = customer;
            account.Rol = _rolRepository.FindByIdAsync(1).Result;

            try
            {
                await _customerRepository.AddAsyn(customer);
                await _accountRepository.AddAsyn(account);
                await _unitOfWork.CompleteAsync();

                return new PersonProfileResponse(customer);
            }
            catch (Exception ex)
            {
                return new PersonProfileResponse($"An error ocurred while saving the customer: {ex.Message}");
            }
        }

        public async Task<PersonProfileResponse> UpdateAsync(int id, PersonProfile customer)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(id);

            if (existingCustomer == null)
                return new PersonProfileResponse("customer not found");

            existingCustomer.Name = customer.Name;
            existingCustomer.LastName= customer.LastName;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Age = customer.Age;
            existingCustomer.Email = customer.Email;
            existingCustomer.Document = customer.Document;
            existingCustomer.Photo = customer.Photo;


            try
            {

                _customerRepository.Update(existingCustomer);
                await _unitOfWork.CompleteAsync();

                return new PersonProfileResponse(existingCustomer);
            }
            catch (Exception ex)
            {
                return new PersonProfileResponse($"An error ocurred while updating the customer: {ex.Message}");
            }
        }
       
        public async Task<PersonProfileResponse> DeleteAsync(int id)
        {
            var existingcustomer = await _customerRepository.FindByIdAsync(id);

            if (existingcustomer == null)
                return new PersonProfileResponse("customer not found.");

            try
            {
                _customerRepository.Remove(existingcustomer);
                await _unitOfWork.CompleteAsync();
                return new PersonProfileResponse(existingcustomer);
            }
            catch (Exception ex)
            {
                return new PersonProfileResponse($"An error ocurred while deleting the customer: {ex.Message}");
            }
         
        }

        public async Task<PersonProfileResponse> FindByIdAsync(int id)
        {

            try
            {
                var customer = await _customerRepository.FindByIdAsync(id);
                var aux = new PersonProfileResponse(customer);
                if (customer == null)
                {
                    aux = new PersonProfileResponse(false, "No se encontro al customer porque no existe", customer);

                }
                return aux;
            }
            catch (Exception ex)
            {
                return new PersonProfileResponse($"An error ocurred while deleting the customer: {ex.Message}");
            }
        }
    }
}
