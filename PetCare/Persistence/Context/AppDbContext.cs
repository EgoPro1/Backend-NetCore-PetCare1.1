using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Models;
using PetCare.Extensions;
using PetCare.Persistence.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }


        public DbSet<PersonProfile> PersonProfiles { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProviderJoinProduct> ProviderJoinProducts { get; set; }
        public DbSet<TypeProduct> TypeProducts{ get; set; }
        public DbSet<MedicalProfile> MedicalProfiles { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
	    public DbSet<VaccinationRecord> VaccinationRecords { get; set; }
        public DbSet<PersonRequest> Requests { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<BusinessProfile> BusinessProfiles{ get; set; }
        public DbSet<Review> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            new PersonProfileConfig(builder.Entity<PersonProfile>());
            new ProductsProviderConfig(builder.Entity<Provider>());
            new PetConfig(builder.Entity<Pet>());
            new PaymentConfig(builder.Entity<Payment>());
            new ReviewConfig(builder.Entity<Review>());

            //Account - SubscriptionPlan (one - many) 
            builder.Entity<SubscriptionPlan>().HasMany(x => x.Accounts)
                .WithOne(p => p.SubscriptionPlan)
                .HasForeignKey(fk => fk.SubscriptionPlanId);

            //PersonProfle
            builder.Entity<PersonProfile>().HasMany(x => x.Pets).
                WithOne(p => p.PersonProfile).HasForeignKey(x => x.PersonProfileId);
            //Provider One-One
            builder.Entity<Provider>().HasOne(x => x.Payment)
                .WithOne(p => p.ServicesProvider)
                .HasForeignKey<Payment>(b => b.ServicesProviderForeignKey);
            
            //ProviderService---------------------------------------------
            /*
            builder.Entity<ProviderJoinProduct>()
            .HasKey(ps => new { ps.ProviderId, ps.TypeProductId});

            builder.Entity<ProviderJoinProduct>()
                .HasOne(ps => ps.Provider)
                .WithMany(wm => wm.ProviderProducts)
                .HasForeignKey(fk => fk.ProviderId);

            builder.Entity<ProviderJoinProduct>()
                .HasOne(ps => ps.TypeProduct)
                .WithMany(wm => wm.providerJoinProducts)
                .HasForeignKey(fk => fk.TypeProductId);
                */
            //TypeService

           /* builder.Entity<TypeProduct>()
                .HasMany(t => t.ListProducts)
                .WithOne(s => s.TypeProduct)
                .HasForeignKey(fk => fk.TypeProductId);
*/
    

            //MedicalProfile One-One Pet
            builder.Entity<Pet>().HasOne(x => x.MedicalProfile)
              .WithOne(p => p.Pet)
              .HasForeignKey<MedicalProfile>(b => b.PetId);

            //MedicalProfe One - Many Provider
            builder.Entity<Provider>().HasMany(x => x.MedicalProfiles)
                .WithOne(p => p.Provider)
                .HasForeignKey(fk => fk.ProviderId);

            //MedicalProfile - MedicalRecord (One-Many)
            builder.Entity<MedicalProfile>().HasMany(x => x.MedicalRecords)
                .WithOne(p => p.MedicalProfile)
                .HasForeignKey(fk => fk.MedicalProfileId);

            //Rol - Account (One - Many)
            builder.Entity<Rol>().HasMany(x => x.Accounts)
                .WithOne(p => p.Rol)
                .HasForeignKey(fk => fk.RolId);

            //Account - PersonProfile
            builder.Entity<Account>().HasOne(x => x.PersonProfile)
                 .WithOne(p => p.Account)
                 .HasForeignKey<PersonProfile>(b => b.AccountId);

            //Account - BusinessProfile
            builder.Entity<Account>().HasOne(x => x.BusinessProfile)
                 .WithOne(p => p.Account)
                 .HasForeignKey<BusinessProfile>(b => b.AccountId);


            //Account - Provider
            /*builder.Entity<Account>().HasOne(x => x.Provider)
                .WithOne(p => p.Account)
                .HasForeignKey<Provider>(b => b.AccountId);*/

            //VaccinationRecord-MedicalProfile
            builder.Entity<MedicalProfile>().HasMany(x => x.VaccinationRecords).
               WithOne(p => p.Profile).HasForeignKey(x => x.ProfileId);

            //PersonProfile - Request ( one - many)
            builder.Entity<PersonProfile>().HasMany(x => x.Requests)
                .WithOne(p => p.PersonProfile)
                .HasForeignKey(fk => fk.PersonProfileId);

            //Product - Request ( one - many)
            builder.Entity<Product>().HasMany(x => x.Requests)
                .WithOne(p => p.Product)
                .HasForeignKey(fk => fk.ProductId);

            //PersonProfile - Review (one - many)
            builder.Entity<PersonProfile>().HasMany(x => x.Reviews)
                .WithOne(p => p.PersonProfile)
                .HasForeignKey(fk => fk.PersonProfileId);

            //Provider - Review (one- many)
            builder.Entity<Provider>().HasMany(x => x.Reviews)
                .WithOne(p => p.Provider)
                .HasForeignKey(fk => fk.ProviderId);

            //Availability One-One Service
            builder.Entity<Product>().HasOne(x => x.Availability)
              .WithOne(p => p.Product)
              .HasForeignKey<Availability>(b => b.ProductId);
            //--------------------------------------------------------------
            //ProviderJoinTypeProduct - Product

             builder.Entity<ProviderJoinProduct>()
                   .HasMany(x => x.Products)
                   .WithOne(p => p.PJP)
                   .HasForeignKey(fk => fk.PJPId);

           /* builder.Entity<Product>()
                .HasOne(p => p.ProviderJoinProduct)
                .WithMany(x => x.Products)
                .HasForeignKey(fk => fk.ProviderJoinTypeProductId);
                */

            //Provider - ProviderJoinTypeProduct
            builder.Entity<Provider>().HasMany(x => x.ProviderProducts)
               .WithOne(p => p.Provider)
               .HasForeignKey(b => b.ProviderId);

            //TypeProduct - ProviderJoinTypeProduct 
            builder.Entity<TypeProduct>().HasMany(x => x.ProviderJoinProducts)
                 .WithOne(p => p.TypeProduct)
                 .HasForeignKey(b => b.TypeProductId);


            builder.Entity<SubscriptionPlan>().HasData
            (
                new SubscriptionPlan { Id = 1, Name = "Free", Description = "Plan Free", Price = 0.0, Duration = 1 },
                new SubscriptionPlan { Id = 2, Name = "Basica", Description = "Plan Basico", Price = 19.90, Duration = 1 },
                new SubscriptionPlan { Id = 3, Name = "Premium", Description = "Plan Premium", Price = 39.90, Duration = 1 }
            );
 
            builder.Entity<Rol>().HasData
             (
                 new Rol { Id = 1, Name = "Usuario", Description = "Busca veterinarias", Publish = false },
                 new Rol { Id = 2, Name = "ServicesProvider", Description = "Ofrece Servicios", Publish = true }
              );

            // Naming conventions Policy
          //  builder.ApplySnakeCaseNamingConvention();

        }
    }
}
