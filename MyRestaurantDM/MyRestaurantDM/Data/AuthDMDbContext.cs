using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyRestaurantDM.Data
{
    public class AuthDMDbContext : IdentityDbContext
    {
        public AuthDMDbContext(DbContextOptions<AuthDMDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var ReaderRoleId = "b1b72831-bfb4-4b08-9089-1090fddaefac"; //Got this ID by Using Guid.NewGuid() in c#Interactive window , it is present in "VIEW/OTHERWINDOW/C#INteractive window"
            var WriterRoleId = "ec9ac709-bdfe-4fdf-b2a5-db22c9a9c896";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = ReaderRoleId,
                    ConcurrencyStamp = ReaderRoleId,
                    Name ="Reader",
                    NormalizedName = "Reader".ToUpper()

                },
                 new IdentityRole
                 {
                    Id = WriterRoleId,
                    ConcurrencyStamp =WriterRoleId,
                    Name ="Writer",
                    NormalizedName = "Writer".ToUpper()

                 }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
