using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRestaurantDM.Data;
using MyRestaurantDM.Models;
using MyRestaurantDM.Repositories;

namespace MyRestaurantDM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MyRestaurantDbContext db;
        private readonly IOrderRepo repo;

        public OrdersController(MyRestaurantDbContext db, IOrderRepo repo)
        {
            this.db = db;
            this.repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var orders = await repo.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orders = await repo.GetOrderById(id);
            return Ok(orders);

        }

        [HttpPost]
        public async Task<IActionResult> Create(OrdersModel orders)
        {
            return Ok(await repo.CreateOrder(orders));
        }

        [HttpPut ("{id}")]
        public async Task<IActionResult> UpdateOrder(int id , OrdersModel orders)
        {
             await repo.UpdateOrder(id, orders);  
            db.SaveChanges();   
            return Ok("Successfully updated😅");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteOrder(int id)
        {
            await repo.DeleteOrder(id);
            db.SaveChanges();
            return Ok("Deleted");
        }

    }
}
