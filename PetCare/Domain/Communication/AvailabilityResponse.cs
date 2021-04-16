using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class AvailabilityResponse:BaseResponse
    {
        public Availability Availability { get; private set; }

        public AvailabilityResponse(bool success, string message, Availability availability) : base(success, message)
        {
            Availability = availability;
        }

        public AvailabilityResponse(Availability availability) : this(true, string.Empty, availability) { }

        public AvailabilityResponse(string message) : this(false, message, null) { }
    }
}
