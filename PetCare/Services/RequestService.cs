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
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IPersonProfileRepository _customerRepository;
        private readonly IProductRepository _productepository;
        private readonly IPetRepository _petRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly ITypeProductRepository _typroduct;

        private readonly IUnitOfWork _unitOfWork;

        public RequestService(IRequestRepository requestRepository, IPersonProfileRepository customerRepository,
            IProductRepository serviceRepository, IUnitOfWork unitOfWork, IPetRepository petRepository, IProviderRepository providerRepository, ITypeProductRepository typeProductRepository)
        {
            _requestRepository = requestRepository;
            _customerRepository = customerRepository;
            _providerRepository = providerRepository;
            _petRepository = petRepository;
            _productepository = serviceRepository;
            _unitOfWork = unitOfWork;
            _typroduct = typeProductRepository;
        }

        public async Task<IEnumerable<PersonRequest>> ListByCostumerIdAsync(int customerId)
        {
            return await _requestRepository.ListByCustomerIdAsync(customerId);
        }

        public async Task<IEnumerable<PersonRequest>> ListByProductIdAsync(int providerId)
        {
            return await _requestRepository.ListByProductIdAsync(providerId);
        }

        public async Task<RequestResponse> SaveByCustomerIdAsync(int customerId, int providerId, int productTypeId, int productId, int petId, PersonRequest request)
        {
            PersonProfile customer = await _customerRepository.FindByIdAsync(customerId);
            TypeProduct type = await _typroduct.FindByIdAsync(productTypeId);
            Product product = await _productepository.FindByIdAsync(productId);
              Pet pet = await _petRepository.FindByIdAsync(petId);
              Provider provider = await _providerRepository.FindByIdAsync(providerId);

            try
            {
                /*    if (  pet.Id == petId )
                    {*/
                request.PetId = pet.Id;
                request.PersonProfileId = customer.Id;
                request.PersonProfile = customer;
                request.ProviderId = provider.Id;
                request.ProductTypeId = productTypeId;
                request.Product = product;
                request.ProductId = productId;
                request.VeterinaryName = provider.BusinessName;
                request.ProductTypeName = type.Name;
                request.ProductName = product.Name;
                request.PetName = pet.Name;
                request.PersonName = customer.Name;
                //Se debera pasar por la app una fecha para asignar ,por el momento para fines de prueba tomamos el dia de hoy
                request.DateReservation = DateTime.Now;
                request.Status = 1;

                await _requestRepository.SaveByCustomerIdAsync(request);
                await _unitOfWork.CompleteAsync();
                return new RequestResponse(request);
                /*      }
                      return new RequestResponse("not found request");
                      */
            }
            catch (Exception ex)
            {
                return new RequestResponse($"An error ocurred while saving the request: {ex.Message}");
            }
        }
        public async Task<RequestResponse> UpdateByCustomerIdAsync( int id, PersonRequest request)
        {
            var existingCustomer = await _requestRepository.FindById(id);

            if (existingCustomer == null)
                return new RequestResponse("request not found");

          
            existingCustomer.Status = request.Status;


            try
            {

                _requestRepository.Update(existingCustomer);
                await _unitOfWork.CompleteAsync();

                return new RequestResponse(existingCustomer);
            }
            catch (Exception ex)
            {
                return new RequestResponse($"An error ocurred while updating the customer: {ex.Message}");
            }

        }

        /*  public async Task<PersonRequest> Update(int requestId, PersonRequest personRequest)
          {
              var RequestDB = await _requestRepository.FindById(requestId);
              RequestDB.DateReservation = personRequest.DateReservation;
          }*/
    }
}