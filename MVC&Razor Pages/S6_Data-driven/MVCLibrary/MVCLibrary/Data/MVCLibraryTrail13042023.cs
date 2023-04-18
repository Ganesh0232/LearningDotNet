using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCLibrary.Models;

    public class MVCLibraryTrail13042023 : DbContext
    {
        public MVCLibraryTrail13042023 (DbContextOptions<MVCLibraryTrail13042023> options)
            : base(options)
        {
        }

        public DbSet<MVCLibrary.Models.Book> Book { get; set; } = default!;
    }
