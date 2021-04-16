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
    [Route("api/business/{businessId}/providers/{providerId}/payments")]
    public class ProviderPaymentsController : ControllerBase
    {
        private readonly IPaymentService _PaymentService;
        private readonly IMapper _mapper;

        public ProviderPaymentsController(IPaymentService PaymentService, IMapper mapper)
        {
            _PaymentService = PaymentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PaymentResource>> GetAllPaymentByProviderId(int providerId)
        {

            var payments = await _PaymentService.ListByServicesProviderIdAsync(providerId);
            var resources = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(payments);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterPaymentByProviderId(int providerId, [FromBody] SavePaymentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var Payment = _mapper.Map<SavePaymentResource, Payment>(resource);
            var result = await _PaymentService.SaveByServicesProviderIdAsync(providerId, Payment);

            if (!result.Success)
                return BadRequest(result.Message);
            var PaymentResource = _mapper.Map<Payment, PaymentResource>(result.payment);
            return Ok(PaymentResource);
        }

        [HttpPut("{paymentId}")]
        public async Task<IActionResult> EditPayment(int paymentId, [FromBody] SavePaymentResource resource)
        {
            var customer = _mapper.Map<SavePaymentResource, Payment>(resource);
            var result = await _PaymentService.UpdateAsync(paymentId, customer);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var customerResource = _mapper.Map<Payment, PaymentResource>(result.payment);
            return Ok(customerResource);
        }

        [HttpDelete("{paymentId}")]
        public async Task<IActionResult> UnRegisterPayment(int paymentId)
        {
            var result = await _PaymentService.DeleteAsync(paymentId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<Payment, PaymentResource>(result.payment);
            return Ok(categoryResource);
        }



    }
}
