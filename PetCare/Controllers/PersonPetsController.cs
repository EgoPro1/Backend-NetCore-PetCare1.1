using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Models;
using PetCare.Domain.Services;
using PetCare.Extensions;
using PetCare.Resources;

namespace PetCare.Controllers
{
    [Authorize]
    [Route("api/people/{personId}/pets")]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IPersonProfileService _personService;
        private readonly IMapper _mapper;

        public PetsController(IPersonProfileService personService,IPetService petService, IMapper mapper)
        {
            _petService = petService;
            _mapper = mapper;
            _personService = personService;
        }

        [HttpGet]
        public async Task<IEnumerable<PetResource>> GetAllPetsByPersonId(int personId)
        {
            var persons = await _petService.ListByCostumerIdAsync(personId);
            var resources = _mapper.Map<IEnumerable<Pet>, IEnumerable<PetResource>>(persons);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterPetByPersonId(int personId, [FromBody] SavePetResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var Cid = await _personService.FindByIdAsync(personId
            );
            if (!Cid.Success)
                return BadRequest(Cid.Message);

            var pet = _mapper.Map<SavePetResource, Pet>(resource);
            var result = await _petService.SaveByCustomerIdAsync(personId, pet);
            if (!result.Success)
                return BadRequest(result.Message);
            var petResource = _mapper.Map<Pet, PetResource>(result.Pet);
            return Ok(petResource);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditPetByPersonId(int personId,int id, [FromBody] SavePetResource resource)
        {
            var Cid = await _personService.FindByIdAsync(personId
            );
            if (!Cid.Success)
                return BadRequest(Cid.Message);
            var pet = _mapper.Map<SavePetResource, Pet>(resource);
            var result = await _petService.UpdateAsync(id, pet);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var petResource = _mapper.Map<Pet, PetResource>(result.Pet);
            return Ok(petResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UnRegisterPetByPersonId(int personId,int id)
        {
            var Cid = await _personService.FindByIdAsync(personId
            );
            if (!Cid.Success)
                return BadRequest(Cid.Message);
            var result = await _petService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<Pet, PetResource>(result.Pet);
            return Ok(categoryResource);
        }
        [HttpGet("{petId}")]
        public async Task<IActionResult> GetPetByPersonId(int personId,int petId)
        {
            var result = await _petService.FindPetByPersonId(personId, petId);
            var petResource = _mapper.Map<Pet, PetResource>(result);
            return Ok(petResource);
        }
    }
}