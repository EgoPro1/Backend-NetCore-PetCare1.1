using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Resources
{
    public class PaymentResource
    {
        public int Id { get; set; }
        public long Number { get; set; }

        public string Name { get; set; }
 
        public int  CVV { get; set; }
  
        public string DateOfExpiry { get; set; }


    }
}
