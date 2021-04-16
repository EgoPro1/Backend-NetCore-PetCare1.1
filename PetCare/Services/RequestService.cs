﻿using PetCare.Domain.Comunication;
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


        private readonly IUnitOfWork _unitOfWork;

        public RequestService(IRequestRepository requestRepository, IPersonProfileRepository customerRepository,
            IProductRepository serviceRepository, IUnitOfWork unitOfWork)
        {
            _requestRepository = requestRepository;
            _customerRepository = customerRepository;
            _productepository = serviceRepository;
            _unitOfWork = unitOfWork;
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
            Product product = await _productepository.FindByIdAsync(productId);
            /*  Pet pet = await _petRepository.FindByIdAsync(petId);
              Provider provider = await _providerRepository.FindByIdAsync(providerId);*/
            try
            {
                /*    if (  pet.Id == petId )
                    {*/
                request.PetId = petId;
                request.PersonProfileId = customerId;
                request.PersonProfile = customer;
                request.ProviderId = providerId;
                request.ProductTypeId = productTypeId;
                request.Product = product;
                request.ProductId = productId;
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

        /*  public async Task<PersonRequest> Update(int requestId, PersonRequest personRequest)
          {
              var RequestDB = await _requestRepository.FindById(requestId);
              RequestDB.DateReservation = personRequest.DateReservation;
          }*/
    }
}