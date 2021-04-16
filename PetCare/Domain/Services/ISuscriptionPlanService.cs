using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface ISuscriptionPlanService
    {
        Task<IEnumerable<SubscriptionPlan>> ListAsync();
        Task<SuscriptionPlanResponse> SaveAsync(SubscriptionPlan suscriptionPlan);
        Task<SuscriptionPlanResponse> UpdateAsync(int id, SubscriptionPlan suscriptionPlan);
        Task<SuscriptionPlanResponse> DeleteAsync(int id);
        Task<SuscriptionPlanResponse> GetById(int id);
    }
}
