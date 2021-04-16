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
        public class RequestRepository : BaseRepository, IRequestRepository
        {
            public RequestRepository(AppDbContext context) : base(context)
            {

            }

        public  async Task<PersonRequest> FindById(int requestId)
        {
            return await _context.Requests.FindAsync(requestId);
        }

        public async Task<IEnumerable<PersonRequest>> ListByCustomerIdAsync(int personProfileId) =>
                await _context.Requests
                .Where(p => p.PersonProfileId == personProfileId)
                .Include(p => p.PersonProfile)
                .ToListAsync();

            public async Task<IEnumerable<PersonRequest>> ListByProductIdAsync(int providerId) =>
                await _context.Requests
                .Where(p => p.ProviderId == providerId)
                .ToListAsync();

            public async Task SaveByCustomerIdAsync(PersonRequest request)
            {
                // var customer = await _context.Customers.FindAsync(customerId);
                // request.CustomerId = customer.Id;
                await _context.Requests.AddAsync(request);
            }

        public void Update(PersonRequest personRequest)
        {
            _context.Requests.Update(personRequest);
        }
    }
 
}
