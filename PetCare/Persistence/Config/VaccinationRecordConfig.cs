using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Config
{
    public class VaccinationRecordConfig
    {
        public class ProfileConfig
        {
            public ProfileConfig(EntityTypeBuilder<VaccinationRecord> entityBuilder)
            {
                entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(30);
                entityBuilder.Property(x => x.Description).IsRequired();
                entityBuilder.Property(x => x.Create_at).IsRequired().HasMaxLength(30);

            }
        }
    }
}