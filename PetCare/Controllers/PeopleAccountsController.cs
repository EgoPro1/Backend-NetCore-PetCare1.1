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
    [Route("api/people")]
    public class PeopleAccountsController : ControllerBase
    {
        private readonly IPersonProfileService _customerService;
        private readonly IMapper _mapper;

        public PeopleAccountsController(IPersonProfileService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<PersonProfileResource>> GetAllPeople()
        {
            
            var customers = await _customerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<PersonProfile>, IEnumerable<PersonProfileResource>>(customers);
            var list = resources.ToList<PersonProfileResource>();
            return list;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {

            var result = await _customerService.FindByIdAsync(id);
            var resources = _mapper.Map<PersonProfile, PersonProfileResource>(result.Customer);
            return Ok(resources);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterPeople([FromBody] SavePersonProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var customer = _mapper.Map<SavePersonProfileResource, PersonProfile>(resource);
            var result = await _customerService.SaveAsync(customer);
            if (!result.Success)
                return BadRequest(result.Message);
            var customerResource = _mapper.Map<PersonProfile, PersonProfileResource>(result.Customer);
            return Ok(customerResource);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditPeopleRegister(int id, [FromBody] SavePersonProfileResource resource)
        {
            var customer = _mapper.Map<SavePersonProfileResource, PersonProfile>(resource);
            var result = await _customerService.UpdateAsync(id, customer);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var customerResource = _mapper.Map<PersonProfile, PersonProfileResource>(result.Customer);
            return Ok(customerResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UnRegisterPeople(int id)
        {
            var result = await _customerService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<PersonProfile, PersonProfileResource>(result.Customer);
            return Ok(categoryResource);
        }
    }
}