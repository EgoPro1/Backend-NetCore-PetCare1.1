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

namespace PetCare.Controllers
{
    [Route("api/business/{businessId}/providers")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _servicesProviderService;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderService servicesProviderService, IMapper mapper)
        {
            _servicesProviderService = servicesProviderService;
            _mapper = mapper;
        }

     

        [HttpPut("{providerId}")]
        public async Task<IActionResult> RegisterProvider(int providerId, [FromBody] SaveProviderResource resource)
        {
            var servicesProvider = _mapper.Map<SaveProviderResource, Provider>(resource);
            var result = await _servicesProviderService.UpdateAsync(providerId, servicesProvider);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var servicesProviderResource = _mapper.Map<Provider, ProviderResource>(result.ProductsProvider);
            return Ok(servicesProviderResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UnRegister(int id)
        {
            var result = await _servicesProviderService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<Provider, ProviderResource>(result.ProductsProvider);
            return Ok(categoryResource);
        }

    }
}