using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IdentityApp;

namespace IdentityApp.Data
{
    public class IdentityAppContext : DbContext
    {
        public IdentityAppContext (DbContextOptions<IdentityAppContext> options)
            : base(options)
        {
        }

        public DbSet<IdentityApp.Invoice> Invoice { get; set; } = default!;
    }
}
