using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class PetResponse : BaseResponse
    {
        public Pet Pet { get; private set; }

        public PetResponse(bool success, string message, Pet pet) : base(success, message)
        {
            Pet = pet;
        }

        public PetResponse(Pet pet) : this(true, string.Empty, pet) { }

        public PetResponse(string message) : this(false, message, null) { }

    }
}
