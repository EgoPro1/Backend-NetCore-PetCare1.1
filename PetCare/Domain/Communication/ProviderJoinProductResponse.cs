using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class ProviderJoinProductResponse : BaseResponse
    {
        public ProviderJoinProduct ProviderJoinProduct { get; private set; }

        public ProviderJoinProductResponse(bool success, string message, ProviderJoinProduct providerJoinProduct) : base(success, message)
        {
            ProviderJoinProduct = providerJoinProduct;
        }

        public ProviderJoinProductResponse(ProviderJoinProduct providerJoinProduct) : this(true, string.Empty, providerJoinProduct) { }

        public ProviderJoinProductResponse(string message) : this(false, message, null) { }
    }
}
