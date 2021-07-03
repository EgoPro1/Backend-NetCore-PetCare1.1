using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Ocsp;
using PetCare.Domain.Models;
using PetCare.Domain.Services;
using PetCare.Extensions;
using PetCare.Resources;
using PetCare.Resources.Save;

namespace PetCare.Controllers
{
    [Authorize]
    [Route("api/people/{personId}/pets/{petId}/providers/{providerId}/product-types/{productTypeId}/products/{productId}/requests")]
    public class PersonRequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public PersonRequestsController(IRequestService RequestService, IMapper mapper)
        {
            _requestService = RequestService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterRequestByPersonId(int personId, int petId, int providerId,int productTypeId, int productId, [FromBody] SaveRequestResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var request = _mapper.Map<SaveRequestResource, PersonRequest>(resource);
            var result = await _requestService.SaveByCustomerIdAsync(personId, providerId, productTypeId, productId, petId, request);
            if (!result.Success)
                return BadRequest(result.Message);
            var requestResource = _mapper.Map<PersonRequest, RequestResource>(result.Request);
            return Ok(requestResource);
        }

        [HttpGet]
        public async Task<IEnumerable<RequestResource>> GetAllRequestByPersonId(int personId)
        {
            var requestDB = await _requestService.ListByCostumerIdAsync(personId);
            var resource = _mapper.Map<IEnumerable<PersonRequest>, IEnumerable<RequestResource>>(requestDB);
            return resource;

        }


    }
}