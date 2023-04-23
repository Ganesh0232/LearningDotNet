using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyRestaurantDM.Data;
using MyRestaurantDM.Models.Domain;

namespace MyRestaurantDM.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly MyRestaurantDbContext db;

        public OrderRepo(MyRestaurantDbContext db)
        {
            this.db=db;
        }
        public async Task<OrdersModel> CreateOrder( OrdersModel orders)
        {
           await db.OrdersDM.AddAsync(orders);
           await db.SaveChangesAsync();

            return orders;
        }

        public async Task<List<OrdersModel>> DeleteOrder(int id)
        {
            var orders = await db.OrdersDM.ToListAsync();
            var order = await db.OrdersDM.FindAsync(id);
            if (order == null)
            {
                return null;
            }

            db.OrdersDM.Remove(order);
            await db.SaveChangesAsync();
            return orders;


        }

        public async Task<OrdersModel> GetOrderById(int id)
        {
            return await db.OrdersDM.FirstOrDefaultAsync(x=>x.OrderId==id);
        }

        public async Task<List<OrdersModel>> GetOrders()
        {
            return await db.OrdersDM.ToListAsync();
        }

        public Task<OrdersModel> OrdersCountperMonth(OrdersModel orders)
        {
            throw new NotImplementedException();
        }

        public async Task<OrdersModel> UpdateOrder(int id, OrdersModel orders)
        {
          var order = await db.OrdersDM.FirstOrDefaultAsync(x => x.OrderId==id);
            if (order == null)
            {
                return null;
            }

            order.CustomerPhone = orders.CustomerPhone;
            order.CustomerName = orders.CustomerName;
            order.CustomerEmail = orders.CustomerEmail;
            order.address = order.address;
            order.Bill = orders.Bill;
            order.CustomerCity = orders.CustomerCity;
            
            await db.OrdersDM.AddAsync(order);
            await db.SaveChangesAsync();
            return orders;
        }

     
    }
}
