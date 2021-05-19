using PetCare.Domain.Communication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IReviewService
    {
        Task<ReviewResponse> SaveByCustomerIdAsync(int personId, int providerId, Review Review);
        Task<ReviewResponse> UpdateAsync(int id, Review review);
        Task<ReviewResponse> DeleteAsync(int id);
        //Task<IEnumerable<Review>> ListCommentByVeterinaryAsync(int VeterinaryId);
        Task<IEnumerable<Review>> ListByCostumerIdAsync(int personId);
        Task<IEnumerable<Review>> ListByProviderIdAsync(int providerId);
    }
}
