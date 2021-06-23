using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Models;
using PetCare.Domain.Services;
using PetCare.Extensions;
using PetCare.Resources;
using PetCare.Resources.Save;

namespace PetCare.Controllers
{
  
    [Route("api/providers")]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _servicesProviderService;
        private readonly IMapper _mapper;

        public ProviderController(IProviderService servicesProviderService, IMapper mapper)
        {
            _servicesProviderService = servicesProviderService;
            _mapper = mapper;
        }

      [HttpGet]
        public async Task<IEnumerable<ProviderResource>> GetAllProviders()
        {

            var providers = await _servicesProviderService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderResource>>(providers);
            return resources;
        }
        
        

        [HttpGet("{providerId}")]
        public async Task<ProviderResource> GetProviderById(int providerId)
        {
            var providerDB = await _servicesProviderService.FindByIdAsync(providerId);
            var resource = _mapper.Map<Provider, ProviderResource>(providerDB.ProductsProvider);
            return resource;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditRegisterReview(int id, [FromBody] SaveReviewResource resource)
        {
            var review = _mapper.Map<SaveReviewResource, Provider>(resource);
            var result = await _servicesProviderService.UpdateAsync(id, review);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var reviewResource = _mapper.Map<Provider, ReviewResource>(result.ProductsProvider);
            return Ok(reviewResource);
        }


    }
}