using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class PersonProfileResponse : BaseResponse
    {
        public PersonProfile Customer { get; private set; }

        public PersonProfileResponse(bool success, string message, PersonProfile customer) : base(success, message)
        {
            Customer = customer;
        }

        public PersonProfileResponse(PersonProfile customer) : this(true, string.Empty, customer) { }

        public PersonProfileResponse(string message) : this(false, message, null) { }

    }
}
