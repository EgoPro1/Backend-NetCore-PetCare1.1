using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PetCare.Domain.Models;
using PetCare.Domain.Repositories;
using PetCare.Domain.Services;
using PetCare.Persistence.Context;
using PetCare.Persistence.Repositories;
using PetCare.Resources;
using PetCare.Services;
using PetCare.Settings;
using System.Text;

namespace PetCare
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            // AppSettings Setup
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // JWT Authentication configuration
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            // Add Authentication Support
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            /*services.AddDbContext<AppDbContext>(opt =>
            opt.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
*/
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));



            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPersonProfileRepository, PersonProfileRepository>();
            services.AddScoped<IPersonProfileService, PersonProfileService>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPetRepository, PetRepository>();


            services.AddScoped<ISuscriptionPlanRepository, SuscriptionPlanRepository>();
            services.AddScoped<ISuscriptionPlanService, SuscriptionPlanService>();

            services.AddScoped<IProviderJoinProductRepository, ProviderJoinProductRepository>();
            services.AddScoped<IProviderJoinProductService, ProviderJoinProductService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ITypeProductRepository, TypeProductRepository>();
            services.AddScoped<ITypeProductService, TypeProductService>();

            services.AddScoped<IMedicalProfileService, MedicalProfileService>();
            services.AddScoped<IMedicalProfileRepository, MedicalProfileRepository>();

            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            services.AddScoped<IMedicalRecordRepository, MedicalRecordRepository>();

            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IRolRepository, RolRepository>();

            services.AddScoped<IVaccinationRecordService, VaccinationRecordService>();
            services.AddScoped<IVaccinationRecordRepository, VaccinationRecordRepository>();

            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IRequestRepository, RequestRepository>();

            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewService, ReviewService>();

            services.AddScoped<IAvailabilityService, AvailabilityService>();
            services.AddScoped<IAvailabilityRepository, AvailabilityRepository>();

            services.AddScoped<IBusinessProfileService, BusinessProfileService>();
            services.AddScoped<IBusinessProfileRepository, BusinessProfileRepository>();

            services.AddScoped<IUnitOfWork, unitOfWork>();


            services.AddCors(options => {
                options.AddPolicy("Todos",
                    builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseCors(x => x
                 .SetIsOriginAllowed(origin => true)
                 .AllowAnyMethod()
                 .AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseHttpsRedirection();


            app.UseRouting();
            // Add Authentication Support
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            }
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
