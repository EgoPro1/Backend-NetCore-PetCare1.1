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
    [Route("api/people/{personId}/requests")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestsController(IRequestService RequestService, IMapper mapper)
        {
            _requestService = RequestService;
            _mapper = mapper;
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