using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class RegionResponse : BaseResponse
    {
        public Region Region { get; private set; }

        public RegionResponse(bool success, string message, Region region) : base(success, message)
        {
            Region = region;
        }

        public RegionResponse(Region region) : this(true, string.Empty, region) { }

        public RegionResponse(string message) : this(false, message, null) { }

    }
}
