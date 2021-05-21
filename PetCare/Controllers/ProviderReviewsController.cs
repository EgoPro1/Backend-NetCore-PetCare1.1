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
    [Route("api/providers/{providerId}/reviews")]
    public class ProviderReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ProviderReviewsController(IReviewService reviewService, IMapper mapper)
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
        //[HttpGet]
        //public async Task<IEnumerable<ReviewResource>> GetAllReviews(int providerId)
        //{
        //    var requests = await _reviewService.ListCommentByVeterinaryAsync(providerId);
        //    var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(requests);
        //    return resources;
        //}

    }
}
