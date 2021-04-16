using AutoMapper;
using PetCare.Domain.Models;
using PetCare.Resources;
using PetCare.Resources.Save;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<PersonProfile, PersonProfileResource>();
            CreateMap<Provider, ProviderResource>();
            CreateMap<Pet, PetResource>();
            CreateMap<Payment, PaymentResource>();
            CreateMap<SubscriptionPlan, SubscriptionPlanResource>();
            CreateMap<Pet, RegisterPetResource>();
            CreateMap<Product, ProductResource>();
            CreateMap<TypeProduct, TypeProductResource>();
            CreateMap<MedicalProfile, MedicalProfileResource>();
            CreateMap<MedicalRecord, MedicalRecordResource>();
            CreateMap<VaccinationRecord, VaccinationRecordResource>();
            CreateMap<PersonRequest, RequestResource>();
            CreateMap<Availability, AvailabilityResource>();
            CreateMap<BusinessProfile, BusinessProfileResource>();
            CreateMap<Review, ReviewResource>();
            CreateMap<ProviderJoinProduct, ProviderJoinProductTypeResource>();

        }
    }
}
