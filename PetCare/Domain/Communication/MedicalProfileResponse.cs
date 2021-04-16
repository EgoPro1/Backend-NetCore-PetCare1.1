using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class MedicalProfileResponse : BaseResponse
    {
        public MedicalProfile MedicalProfile { get; private set; }

        public MedicalProfileResponse(bool success, string message, MedicalProfile medicalprofile) : base(success, message)
        {
            MedicalProfile = medicalprofile;
        }

        public MedicalProfileResponse(MedicalProfile medicalprofile) : this(true, string.Empty, medicalprofile) { }

        public MedicalProfileResponse(string message) : this(false, message, null) { }

    }
}
