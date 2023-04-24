using Microsoft.EntityFrameworkCore;
using MyRestaurantDM.Models.Domain;
using MyRestaurantDM.Models.DTO;

namespace MyRestaurantDM.Data
{
    public class MyRestaurantDbContext : DbContext
    {


        public MyRestaurantDbContext(DbContextOptions<MyRestaurantDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        
        public DbSet<ItemModel> ItemsDM { get; set; }
        public DbSet<OrdersModel> OrdersDM { get; set; }
      //  public DbSet<OrderDto> Ordereddto { get; set; }



    }
}


