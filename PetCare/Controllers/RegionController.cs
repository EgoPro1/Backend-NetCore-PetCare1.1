using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Models;
using PetCare.Domain.Services;
using PetCare.Extensions;
using PetCare.Resources;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetCare.Controllers
{
    [Route("api/regions")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;
        private readonly IMapper _mapper;

        public RegionController(IRegionService regionService, IMapper mapper)
        {
            _regionService = regionService;
            _mapper = mapper;
        }



        [HttpPost]
        public async Task<ActionResult> RegisterRegion([FromBody] SaveRegionResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var region = _mapper.Map<SaveRegionResource, Region>(resource);
            var result = await _regionService.SaveAsync(region);

            if (!result.Success)
                return BadRequest(result.Message);
            var customerResource = _mapper.Map<Region, RegionResource>(result.Region);
            return Ok(customerResource);
        }
/*
        [HttpGet("{businessId}")]
        public async Task<BusinessProfileResource> GetBusinessProfileByProviderId(int businessId)
        {
            var businessDB = await _regionService.FindByBusinessId(businessId);
            var resources = _mapper.Map<Region, RegionResource>(businessDB);

            return resources;
        }
        */
        [HttpGet]
        public async Task<IEnumerable<RegionResource>> GetAllRegion()
        {
            var region = await _regionService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Region>, IEnumerable<RegionResource>>(region);
            return resources;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditRegionRegister(int id, [FromBody] SaveRegionResource resource)
        {
            var region = _mapper.Map<SaveRegionResource, Region>(resource);
            var result = await _regionService.UpdateAsync(id, region);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var customerResource = _mapper.Map<Region,RegionResource>(result.Region);
            return Ok(customerResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UnRegion(int id)
        {
            var result = await _regionService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<Region, RegionResource>(result.Region);
            return Ok(categoryResource);
        }

    }
}

