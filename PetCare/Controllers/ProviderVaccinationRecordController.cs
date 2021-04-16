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
    [Route("api/business/{businessId}/providers/{providerId}/people/{customerId}/pets/{petId}/petprofiles/{profileId}/vaccinationrecords")]
    public class ProviderPetProfilesVRecordsController : ControllerBase
    {
        private readonly IMedicalProfileService _profileService;
        private readonly IPersonProfileService _customerService;
        private readonly IPetService _petService;
        private readonly IProviderService _providerService;
        private readonly IVaccinationRecordService _vaccinationRecordService;
        private readonly IMapper _mapper;


        public ProviderPetProfilesVRecordsController(IMedicalProfileService profileService, IPersonProfileService customerService, IPetService petService, IProviderService providerService, IVaccinationRecordService vaccinationRecordService, IMapper mapper)
        {
            _profileService = profileService;
            _customerService = customerService;
            _petService = petService;
            _providerService = providerService;
            _vaccinationRecordService = vaccinationRecordService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<VaccinationRecordResource>> GetAllAsync(int providerId, int customerId, int petId,int profileId)
        {
            var customers = await _vaccinationRecordService.ListByProfileIdAsync(profileId);
            var resources = _mapper.Map<IEnumerable<VaccinationRecord>, IEnumerable<VaccinationRecordResource>>(customers);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(int providerId, int customerId,int petId,int profileId, [FromBody] SaveVaccinationRecordResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var Prid = await _providerService.FindByIdAsync(providerId
              );
            if (!Prid.Success)
                return BadRequest(Prid.Message);


            var Cid = await _customerService.FindByIdAsync(customerId
             );
            if (!Cid.Success)
                return BadRequest(Cid.Message);

            var Pid = await _petService.FindByIdAsync(petId
          );
            if (!Pid.Success)
                return BadRequest(Pid.Message);

            var Proid = await _profileService.FindByIdAsync(profileId
      );
            if (!Proid.Success)
                return BadRequest(Proid.Message);


            //DEBO COPIAR LA FUNCION DE DE BUSCAR LA LISTA DE MASCOTAS POR ID DE CUSTOMER PARA QUE POR ID DE MEDICALPROFILE PODER RECUPERAR TODOS LOS VACCINATION
            var vaccinationRecord = _mapper.Map<SaveVaccinationRecordResource, VaccinationRecord>(resource);
            var result = await _vaccinationRecordService.SaveByProfileIdAsync(profileId, vaccinationRecord);
            if (!result.Success)
                return BadRequest(result.Message);
            var VaccinationRecordResource = _mapper.Map<VaccinationRecord, VaccinationRecordResource>(result.VaccinationRecord);
            return Ok(VaccinationRecordResource);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int providerId, int customerId, int petId, int profileId, int id, [FromBody] SaveVaccinationRecordResource resource)
        {
            var Prid = await _providerService.FindByIdAsync(providerId
              );
            if (!Prid.Success)
                return BadRequest(Prid.Message);


            var Cid = await _customerService.FindByIdAsync(customerId
             );
            if (!Prid.Success)
                return BadRequest(Cid.Message);

            var Pid = await _petService.FindByIdAsync(petId
          );
            if (!Pid.Success)
                return BadRequest(Pid.Message);

            var Proid = await _profileService.FindByIdAsync(profileId
     );
            if (!Proid.Success)
                return BadRequest(Proid.Message);

            var vaccinationRecord = _mapper.Map<SaveVaccinationRecordResource, VaccinationRecord>(resource);
            var result = await _vaccinationRecordService.UpdateAsync(id, vaccinationRecord);
            if (!result.Success)
                return BadRequest(result.Message);
            var VaccinationRecordResource = _mapper.Map<VaccinationRecord, VaccinationRecordResource>(result.VaccinationRecord);
            return Ok(VaccinationRecordResource);


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int providerId, int customerId, int petId,int profileId ,int id)
        {
            var Prid = await _providerService.FindByIdAsync(providerId
             );
            if (!Prid.Success)
                return BadRequest(Prid.Message);


            var Cid = await _customerService.FindByIdAsync(customerId
             );
            if (!Prid.Success)
                return BadRequest(Cid.Message);

            var Pid = await _petService.FindByIdAsync(petId
          );
            if (!Pid.Success)
                return BadRequest(Pid.Message);

            var Proid = await _profileService.FindByIdAsync(profileId
 );
            if (!Proid.Success)
                return BadRequest(Proid.Message);

        
            var result = await _vaccinationRecordService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var VaccinationRecordResource = _mapper.Map<VaccinationRecord, VaccinationRecordResource>(result.VaccinationRecord);
            return Ok(VaccinationRecordResource);
        }
    }
}