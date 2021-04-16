using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class PaymentResponse : BaseResponse
    {
        public Payment payment { get; private set; }

        public PaymentResponse(bool success, string message, Payment Payment) : base(success, message)
        {
            payment = Payment;
        }

        public PaymentResponse(Payment Payment) : this(true, string.Empty, Payment) { }

        public PaymentResponse(string message) : this(false, message, null) { }

    }
}
