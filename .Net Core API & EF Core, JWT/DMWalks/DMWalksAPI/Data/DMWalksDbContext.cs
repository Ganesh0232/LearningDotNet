using DMWalksAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DMWalksAPI.Data
{
    public class DMWalksDbContext : DbContext
    {
        public DMWalksDbContext( DbContextOptions dbContextOptions) :base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public  DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }  
    }
}
