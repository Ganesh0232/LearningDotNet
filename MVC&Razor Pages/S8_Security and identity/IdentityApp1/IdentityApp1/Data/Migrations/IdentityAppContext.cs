using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityApp1;


namespace IdentityApp1.Data.Migrations
{
    public class IdentityAppContext : DbContext
    {


        public IdentityAppContext(DbContextOptions<IdentityAppContext> options)
            : base(options)
        {
        }

        public DbSet<IdentityApp1.Invoice> Invoice { get; set; } = default!;
    }
}


