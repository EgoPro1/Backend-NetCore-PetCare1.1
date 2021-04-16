using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class ProviderResponse : BaseResponse
    {
        public Provider ProductsProvider { get; private set; }
        public ProviderResponse(bool success, string message, Provider productsProvider) : base(success, message)
        {
            ProductsProvider = productsProvider;
        }
        public ProviderResponse(Provider productsProvider) : this(true, string.Empty, productsProvider)
        { }

        public ProviderResponse(string message) : this(false, message, null) { }
    }
}
