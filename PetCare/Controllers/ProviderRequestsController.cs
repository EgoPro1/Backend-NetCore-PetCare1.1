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
using PetCare.Resources.Save;

namespace PetCare.Controllers
{
    [Authorize]

    [Route("api/business/{business}/providers/{providerId}/request")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestController(IRequestService RequestService, IMapper mapper)
        {
            _requestService = RequestService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RequestResource>> GetAllRequestByProductId(int providerId)
        {
            var requests = await _requestService.ListByProductIdAsync(providerId);
            var resources = _mapper.Map<IEnumerable<PersonRequest>, IEnumerable<RequestResource>>(requests);
            return resources;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditStatus(int id, [FromBody] SaveRequestResource resource)
        {
            var request = _mapper.Map<SaveRequestResource, PersonRequest>(resource);
            var result = await _requestService.UpdateByCustomerIdAsync(id, request);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var customerResource = _mapper.Map<PersonRequest, RequestResource>(result.Request);
            return Ok(customerResource);
        }

    }
}