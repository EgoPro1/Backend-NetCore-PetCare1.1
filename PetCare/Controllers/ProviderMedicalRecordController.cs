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
    [Route("api/business/{businessId}/providers/{providerId}/people/{personId}/pets/{petId}/petprofiles/{profileId}/medicalrecords")]
    public class ProviderMedicalRecordController : ControllerBase
    {
        private readonly IMedicalProfileService _medicalprofileService;
        private readonly IMedicalRecordService _medicalrecordService;
        private readonly IPersonProfileService _customerService;
        private readonly IPetService _petService;
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;

        public ProviderMedicalRecordController( IProviderService providerService, IPetService petService, IPersonProfileService customerService,IMedicalProfileService medicalprofileService, IMedicalRecordService medicalrecordService, IMapper mapper)
        {
            _medicalprofileService = medicalprofileService;
            _medicalrecordService = medicalrecordService;
            _customerService = customerService;
            _petService=petService;
            _providerService = providerService;

            _mapper = mapper;
        }
  

        [HttpPost]
        public async Task<ActionResult> RegisterMedicalRecord(int profileId, int personId, int petId,int providerId, [FromBody] SaveMedicalRecordResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

       

            var medicalrecord = _mapper.Map<SaveMedicalRecordResource, MedicalRecord>(resource);
            var result = await _medicalrecordService.SaveByProfileIdAsync(profileId, medicalrecord);
            if (!result.Success)
                return BadRequest(result.Message);
            var MedicalRecordResource = _mapper.Map<MedicalRecord, MedicalRecordResource>(result.MedicalRecord);
            return Ok(MedicalRecordResource);
        }

        [HttpGet]
        public async Task<IEnumerable<MedicalRecordResource>> ListByProfileId(int profileId)
        {
           
            var result = await _medicalrecordService.ListByProfileIdAsync(profileId);
           
            var MedicalRecordResource = _mapper.Map<IEnumerable<MedicalRecord>, IEnumerable<MedicalRecordResource> >(result);
            return (MedicalRecordResource);
        }
    }
}