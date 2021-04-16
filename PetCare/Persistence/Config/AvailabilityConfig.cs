using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Config
{
    public class AvailabilityConfig
    {
        public AvailabilityConfig(EntityTypeBuilder<Availability> entityBuilder)
        {
            entityBuilder.Property(x => x.DayAvailability).IsRequired();
            entityBuilder.Property(x => x.StartTime).IsRequired().HasMaxLength(5);
            entityBuilder.Property(x => x.EndTime).IsRequired().HasMaxLength(5);


        }
    }
}
