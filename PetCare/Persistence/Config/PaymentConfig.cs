using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Config
{
    public class PaymentConfig
    {
        public PaymentConfig(EntityTypeBuilder<Payment> entityBuilder)
        {   
            entityBuilder.Property(x => x.Number).IsRequired();
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.CVV).IsRequired();
            entityBuilder.Property(x => x.DateOfExpiry).IsRequired().HasMaxLength(8); 
          

        }

    }
}
