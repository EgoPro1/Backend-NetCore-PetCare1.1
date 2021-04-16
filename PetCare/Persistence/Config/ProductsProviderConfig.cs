using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Config
{
    public class ProductsProviderConfig
    {
        public ProductsProviderConfig(EntityTypeBuilder<Provider> entityBuilder)
        {
            entityBuilder.Property(x => x.BusinessName).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Address).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Email).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Field).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Region).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(50);
        }
    }
}
