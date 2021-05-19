using PetCare.Domain.Communication;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Services
{

    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IPersonProfileRepository _personProfileRepository;
        private readonly IProviderRepository _providerRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IReviewRepository reviewRepository, IPersonProfileRepository personProfileRepository, IProviderRepository providerRepository, IUnitOfWork unitOfWork)
        {
            _reviewRepository = reviewRepository;
            _personProfileRepository = personProfileRepository;
            _providerRepository = providerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Review>> ListByCostumerIdAsync(int personId)
        {
            return await _reviewRepository.ListByCustomerIdAsync(personId);
        }
        //public async Task<IEnumerable<Review>> ListCommentByVeterinaryAsync(int VeterinaryId)
        //{
        //    return await _reviewRepository.ListCommentByVeterinaryAsync(VeterinaryId);
        //}
        public async Task<IEnumerable<Review>> ListByProviderIdAsync(int providerId)
        {
            return await _reviewRepository.ListByProviderIdAsync(providerId);
        }

        public async Task<ReviewResponse> SaveByCustomerIdAsync(int personId, int providerId, Review Review)
        {
            PersonProfile customer = await _personProfileRepository.FindByIdAsync(personId);
            Provider provider = await _providerRepository.FindByIdAsync(providerId);

            try
            {

                Review.PersonProfile = customer;
                Review.PersonProfileId = personId;
                Review.Provider = provider;
                Review.ProviderId = providerId;

                await _reviewRepository.SaveByCustomerIdAsync(Review);
                await _unitOfWork.CompleteAsync();
                return new ReviewResponse(Review);

            }
            catch (Exception ex)
            {
                return new ReviewResponse($"An error ocurred while saving the review: {ex.Message}");
            }
        }

        public async Task<ReviewResponse> UpdateAsync(int id, Review review)
        {
            var existingReview = await _reviewRepository.FindByIdAsync(id);

            if (existingReview == null)
                return new ReviewResponse("review not found");

            existingReview.Commentary = review.Commentary;
            existingReview.Qualification = review.Qualification;

            try
            {
                _reviewRepository.Update(existingReview);
                await _unitOfWork.CompleteAsync();

                return new ReviewResponse(existingReview);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"An error ocurred while updating the review: {ex.Message}");
            }
        }

        public async Task<ReviewResponse> DeleteAsync(int id)
        {
            var existingReview = await _reviewRepository.FindByIdAsync(id);

            if (existingReview == null)
                return new ReviewResponse("review not found.");

            try
            {
                _reviewRepository.Remove(existingReview);
                await _unitOfWork.CompleteAsync();
                return new ReviewResponse(existingReview);
            }
            catch (Exception ex)
            {
                return new ReviewResponse($"An error ocurred while deleting the review: {ex.Message}");
            }
            throw new NotImplementedException();
        }
    }
}
