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
using Senparc.Weixin.Entities;

namespace PetCare.Controllers
{
  
    [Route("api/providers/address")]
    public class ProviderSearchController : ControllerBase
    {
        private readonly IProviderService _servicesProviderService;
        private readonly IMapper _mapper;

        public ProviderSearchController(IProviderService servicesProviderService, IMapper mapper)
        {
            _servicesProviderService = servicesProviderService;
            _mapper = mapper;
        }

  
        [HttpGet]
        public async Task<IEnumerable<ProviderResource>> GetProviderbyAdress([FromBody] AddressResource address)
        {
            var providers = await _servicesProviderService.ListByAddressAsync(address);
            var resources = _mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderResource>>(providers);
            return resources;
        }

        //public async <IJsonResult> GetProviderbyAdress([FromBody] AddressResource address)
        //{
        //    var providers = await _servicesProviderService.ListByAddressAsync(address);
        //    var resources = providers;
        //    return Ok(value: resources);
        //}

    }
}