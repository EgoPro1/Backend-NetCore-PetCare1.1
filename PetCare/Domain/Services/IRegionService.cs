using PetCare.Domain.Comunication;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Services
{
    public interface IRegionService
    {
        Task<IEnumerable<Region>> ListAsync();
        Task<RegionResponse> SaveAsync(Region region);
        Task<RegionResponse> UpdateAsync(int id, Region region);
        Task<RegionResponse> DeleteAsync(int id);
        Task<Region> FindByRegionId(int id);
       
     

    }
}
