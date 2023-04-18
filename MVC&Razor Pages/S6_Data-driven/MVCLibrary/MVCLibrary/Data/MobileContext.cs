using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCLibrary.Models;

    public class MobileContext : DbContext
    {
        public MobileContext (DbContextOptions<MobileContext> options)
            : base(options)
        {
        }

        public DbSet<MVCLibrary.Models.Mobiles> Mobiles { get; set; } = default!;
    }
