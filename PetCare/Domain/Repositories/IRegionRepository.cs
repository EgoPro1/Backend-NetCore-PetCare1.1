using System;
using PetCare.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> ListAsync();
        Task AddAsyn(Region region);
        void Update(Region region);
        void Remove(Region region);
        Task<IEnumerable<Region>> ListFindByregionId(int providerId);
        Task<Region> FindByRegionId(int id);
    }
}


