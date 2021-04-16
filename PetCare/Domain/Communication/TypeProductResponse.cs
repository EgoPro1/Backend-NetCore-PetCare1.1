using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class TypeProductResponse : BaseResponse
    {
        public TypeProduct TypeProduct { get; private set; }

        public TypeProductResponse(bool success, string message, TypeProduct typeProduct) : base(success, message)
        {
            TypeProduct = typeProduct;
        }

        public TypeProductResponse(TypeProduct typeProduct) : this(true, string.Empty, typeProduct) { }

        public TypeProductResponse(string message) : this(false, message, null) { }

    }
}
