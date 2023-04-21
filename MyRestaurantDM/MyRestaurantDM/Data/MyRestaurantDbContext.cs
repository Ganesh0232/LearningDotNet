using Microsoft.EntityFrameworkCore;
using MyRestaurantDM.Models;

namespace MyRestaurantDM.Data
{
    public class MyRestaurantDbContext: DbContext
    {

   
            public MyRestaurantDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
            {

            }

            public DbSet<ItemModel> ItemsDM{ get; set; }
            public DbSet<OrdersModel> OrdersDM { get; set; }

           
        }
    }


