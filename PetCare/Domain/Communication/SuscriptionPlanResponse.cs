using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class SuscriptionPlanResponse : BaseResponse
    {
        public SubscriptionPlan SuscriptionPlan { get; private set; }

        public SuscriptionPlanResponse(bool success, string message, SubscriptionPlan suscriptionPlan) : base(success, message)
        {
            SuscriptionPlan = suscriptionPlan;
        }

        public SuscriptionPlanResponse(SubscriptionPlan suscriptionPlan) : this(true, string.Empty, suscriptionPlan) { }

        public SuscriptionPlanResponse(string message) : this(false, message, null) { }

    }
}
