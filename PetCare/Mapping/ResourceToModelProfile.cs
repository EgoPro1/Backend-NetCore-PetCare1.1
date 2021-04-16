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
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePersonProfileResource, PersonProfile>();
            CreateMap<SaveProviderResource, Provider>();
            CreateMap<SavePetResource, Pet>();
            CreateMap<SaveSubscriptionPlan, SubscriptionPlan>();
            CreateMap<SavePaymentResource, Payment>();
            CreateMap<SaveRegisterPetResource, Pet>();
            CreateMap<SaveProductResource, Product>();
            CreateMap<SaveProductTypeResource, TypeProduct>();
            CreateMap<SaveMedicalProfileResource, MedicalProfile>();
            CreateMap<SaveMedicalRecordResource, MedicalRecord>();
            CreateMap<SaveVaccinationRecordResource,VaccinationRecord >();
            CreateMap<SaveRequestResource, PersonRequest>();
            CreateMap<SaveAvailabilityResource, Availability>();
            CreateMap<SaveBusinessProfileResource, BusinessProfile>();
            CreateMap<SaveReviewResource, Review>();


        }
    }
}
