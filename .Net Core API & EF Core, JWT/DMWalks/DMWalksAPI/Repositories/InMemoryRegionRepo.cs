using DMWalksAPI.Models.Domain;
using Microsoft.Identity.Client;

namespace DMWalksAPI.Repositories
{
    public class InMemoryRegionRepo : IRegionRepo
    {
        public Task<Region> CreateAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region>()
           {
               new Region()
               {
                   Id=Guid.NewGuid(),
                   Code = "G232",
                   Name = "Ganesh Kumar Marrapu",
                   RegionImageUrl="dm232.jpg"
               }
           };
        }

        public Task<Region?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region?> UpdateAsync(Guid id, Region region)
        {
            throw new NotImplementedException();
        }
    }
}
