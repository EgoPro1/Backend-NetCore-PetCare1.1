using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Comunication
{
    public class BaseResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        
//4654     

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
