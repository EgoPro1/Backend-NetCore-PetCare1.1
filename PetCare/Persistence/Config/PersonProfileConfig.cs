using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Config
{
    public class PersonProfileConfig
    {
        public PersonProfileConfig(EntityTypeBuilder<PersonProfile> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            entityBuilder.Property(x => x.LastName).IsRequired().HasMaxLength(30);


        }

    }
}
