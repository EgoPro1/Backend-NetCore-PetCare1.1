using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class BusinessProfileResponse : BaseResponse
    {
        public BusinessProfile BusinessProfile { get; private set; }

        public BusinessProfileResponse(bool success, string message, BusinessProfile businessProfile) : base(success, message)
        {
            BusinessProfile = businessProfile;
        }

        public BusinessProfileResponse(BusinessProfile BusinessProfile) : this(true, string.Empty, BusinessProfile) { }

        public BusinessProfileResponse(string message) : this(false, message, null) { }

    }
}
