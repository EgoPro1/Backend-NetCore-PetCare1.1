using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class VaccinationRecordResponse :BaseResponse
    {
        public VaccinationRecord VaccinationRecord { get; private set; }
        public VaccinationRecordResponse(bool success, string message, VaccinationRecord vaccinationRecord) : base(success, message)
        {
            VaccinationRecord = vaccinationRecord;
        }
        public VaccinationRecordResponse(VaccinationRecord vaccinationRecord) : this(true, string.Empty, vaccinationRecord)
        { }

        public VaccinationRecordResponse(string message) : this(false, message, null) { }
    }
}
