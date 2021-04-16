using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Models;
using PetCare.Domain.Services;
using PetCare.Extensions;
using PetCare.Resources;
using PetCare.Resources.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Controllers
{
    [Authorize]
    [Route("api/people/{personId}/providers/{providerId}/reviews")]
    public class PersonReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public PersonReviewsController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ReviewResource>> GetAllAsync(int providerId)
        {
            var reviews = await _reviewService.ListByProviderIdAsync(providerId);
            var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(reviews);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterReview(int personId, int providerId, [FromBody] SaveReviewResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            var review = _mapper.Map<SaveReviewResource, Review>(resource);
            var result = await _reviewService.SaveByCustomerIdAsync(personId, providerId, review);
            if (!result.Success)
                return BadRequest(result.Message);
            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Review);
            return Ok(reviewResource);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditRegisterReview(int id, [FromBody] SaveReviewResource resource)
        {
            var review = _mapper.Map<SaveReviewResource, Review>(resource);
            var result = await _reviewService.UpdateAsync(id, review);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var reviewResource = _mapper.Map<Review, ReviewResource>(result.Review);
            return Ok(reviewResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UnRegisterReview(int id)
        {
            var result = await _reviewService.DeleteAsync(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var categoryResource = _mapper.Map<Review, ReviewResource>(result.Review);
            return Ok(categoryResource);
        }

    }
}
