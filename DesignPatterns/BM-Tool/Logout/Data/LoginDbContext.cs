using Microsoft.EntityFrameworkCore;
using Logout.Models;

namespace Logout.Data
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<LoginModel> Credentials { get; set; }
    }
}
