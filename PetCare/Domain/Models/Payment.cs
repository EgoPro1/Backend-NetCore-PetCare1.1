using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public long Number { get; set; }
        public string Name { get; set; }
        public int CVV { get; set; }
        public string DateOfExpiry { get; set; }

        public int ServicesProviderForeignKey { get; set; }
        public Provider ServicesProvider { get; set; }

    }
}
