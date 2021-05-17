using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Repositories
{
    public class ReviewRepository : BaseRepository, IReviewRepository
    {

        public ReviewRepository(AppDbContext context) : base(context)
        {

        }

        public async Task AddAsyn(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }

        public async Task<Review> FindByIdAsync(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<IEnumerable<Review>> ListAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public void Remove(Review review)
        {
            _context.Reviews.Remove(review);
        }

        public void Update(Review review)
        {
            _context.Update(review);
        }


        public async Task<IEnumerable<Review>> ListByCustomerIdAsync(int personId) =>
            await _context.Reviews
            .Where(p => p.PersonProfileId == personId)
            .Include(p => p.PersonProfile)
            .ToListAsync();

        public async Task<IEnumerable<Review>> ListCommentByVeterinaryAsync(int VeterinaryId) =>
            await _context.Reviews
            .Where(p => p.ProviderId == VeterinaryId)
            .Include(p => p.PersonProfile)            
            .Include(p => p.Commentary)
            .Include(p => p.Qualification)
            .ToListAsync();        
        public async Task<IEnumerable<Review>> ListByProviderIdAsync(int providerId) =>
            await _context.Reviews
            .Where(p => p.ProviderId == providerId)
            .Include(p => p.Provider)
            .ToListAsync();

        public async Task SaveByCustomerIdAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }
    }
}
