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
//54565
namespace PetCare.Controllers
{
    [Authorize]
    [Route("api/people/{personId}/pets/{petId}/petprofiles")]
    public class PetMedicalProfilesController : ControllerBase
    {
        private readonly IMedicalProfileService _medicalprofileService;
        private readonly IMedicalRecordService _medicalrecordService;
        private readonly IMapper _mapper;

        public PetMedicalProfilesController(IMedicalProfileService medicalprofileService, IMedicalRecordService medicalrecordService, IMapper mapper)
        {
            _medicalprofileService = medicalprofileService;
            _medicalrecordService = medicalrecordService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MedicalProfileResource>> GetProfileByPetId(int personId, int petId)
        {
            var people = await _medicalprofileService.ListByCustomerIdAndPetIdAsync(personId, petId);
            var resources = _mapper.Map<IEnumerable<MedicalProfile>, IEnumerable<MedicalProfileResource>>(people);
            return resources;
        }

    }
}