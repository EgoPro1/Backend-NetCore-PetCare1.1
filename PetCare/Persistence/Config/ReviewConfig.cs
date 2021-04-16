using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Config
{
    public class ReviewConfig
    {
        public ReviewConfig(EntityTypeBuilder<Review> entityBuilder)
        {
            entityBuilder.Property(x => x.Commentary).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Qualification).IsRequired();
        }
    }
}
