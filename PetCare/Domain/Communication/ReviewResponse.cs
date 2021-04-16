using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Communication
{
    public class ReviewResponse : BaseResponse
    {
        public Review Review { get; private set; }

        public ReviewResponse(bool success, string message, Review review) : base(success, message)
        {
            Review = review;
        }

        public ReviewResponse(Review review) : this(true, string.Empty, review) { }

        public ReviewResponse(string message) : this(false, message, null) { }
    }
}
