using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Config
{
    public class PetConfig
    {
        public PetConfig(EntityTypeBuilder<Pet> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Age).IsRequired();
            entityBuilder.Property(x => x.Breed).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.Photo).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Sex).IsRequired().HasMaxLength(50);


        }

    }
}
