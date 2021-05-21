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
    [Route("api/business")]
    public class BusinessAccountController : ControllerBase
    {
        private readonly IBusinessProfileService _businessService;
        private readonly IMapper _mapper;

        public BusinessAccountController(IBusinessProfileService businessService, IMapper mapper)
        {
            _businessService = businessService;
            _mapper = mapper;
        }

    

        [HttpPost]
        public async Task<ActionResult> RegisterAccount([FromBody] SaveBusinessProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var businessProfile = _mapper.Map<SaveBusinessProfileResource, BusinessProfile>(resource);
            var result = await _businessService.SaveAsync(businessProfile);
            if (!result.Success)
                return BadRequest(result.Message);
            var customerResource = _mapper.Map<BusinessProfile, BusinessProfileResource>(result.BusinessProfile);
            return Ok(customerResource);
        }

        [HttpGet("{businessId}")]
        public async Task<BusinessProfileResource> GetBusinessProfileByProviderId(int businessId)
        {
            var businessDB = await _businessService.FindByBusinessId(businessId);
            var resources = _mapper.Map<BusinessProfile, BusinessProfileResource>(businessDB);

            return resources;
        }

        [HttpGet]
        public async Task<IEnumerable<BusinessProfileResource>> GetAllBusiness()
        {
            var business = await _businessService.ListAsync();
            var resources = _mapper.Map<IEnumerable<BusinessProfile>, IEnumerable<BusinessProfileResource>>(business);
            return resources;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditBusinessRegister(int id, [FromBody] SaveBusinessProfileResource resource)
        {
            var business = _mapper.Map<SaveBusinessProfileResource, BusinessProfile>(resource);
            var result = await _businessService.UpdateAsync(id,business);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var customerResource = _mapper.Map<BusinessProfile, BusinessProfileResource>(result.BusinessProfile);
            return Ok(customerResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UnBusinessPeople(int id)
        {
            var result = await _businessService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<BusinessProfile, BusinessProfileResource>(result.BusinessProfile);
            return Ok(categoryResource);
        }

    }
}