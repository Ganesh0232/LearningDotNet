using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using MyRestaurantDM.Models.Domain;

namespace MyRestaurantDM.Repositories
{
    public interface IOrderRepo
    {
        Task<List<OrdersModel>> GetOrders();
            
        Task<OrdersModel> GetOrderById(int id);

        Task<OrdersModel> CreateOrder(OrdersModel orders);

        Task<List<OrdersModel>> DeleteOrder (int id);

        Task<OrdersModel> UpdateOrder(int id,OrdersModel orders);

        Task<OrdersModel> OrdersCountperMonth(OrdersModel orders);
    }
}
