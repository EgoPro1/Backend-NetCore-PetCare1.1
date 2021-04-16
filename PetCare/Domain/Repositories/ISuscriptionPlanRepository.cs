using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface ISuscriptionPlanRepository
    {
        Task<IEnumerable<SubscriptionPlan>> ListAsync();
        Task AddAsyn(SubscriptionPlan suscriptionPlan);
        Task<SubscriptionPlan> FindByIdAsync(int id);
        void Update(SubscriptionPlan suscriptionPlan);
        void Remove(SubscriptionPlan suscriptionPlan);
    }
}
