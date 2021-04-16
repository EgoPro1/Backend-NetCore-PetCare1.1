using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class MedicalRecordResponse : BaseResponse
    {
        public MedicalRecord MedicalRecord { get; private set; }

        public MedicalRecordResponse(bool success, string message, MedicalRecord medicalRecord) : base(success, message)
        {
            MedicalRecord = medicalRecord;
        }

        public MedicalRecordResponse(MedicalRecord medicalRecord) : this(true, string.Empty, medicalRecord) { }

        public MedicalRecordResponse(string message) : this(false, message, null) { }

    }
}
