using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserStories.Models;

namespace UserStories.Data
{
    public class UserStoriesContext : DbContext
    {
        public UserStoriesContext (DbContextOptions<UserStoriesContext> options)
            : base(options)
        {
        }

        public DbSet<UserStories.Models.RegisterModel> RegisterModel { get; set; } = default!;
    }
}
