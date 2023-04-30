using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRestaurantDM.Data;
using MyRestaurantDM.Models.Domain;
using MyRestaurantDM.Models.DTO;
using MyRestaurantDM.Repositories;
using System.Text.Json;

namespace MyRestaurantDM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly MyRestaurantDbContext db;
        private readonly IOrderRepo repo;
        private readonly IMapper mapper;
        private  ILogger<OrdersController> loger { get; }

        public OrdersController(MyRestaurantDbContext db, IOrderRepo repo , IMapper mapper , ILogger<OrdersController> loger)
        {
            this.db = db;
            this.repo = repo;
            this.mapper = mapper;
            this.loger = loger;
        }

        [HttpGet]
      // [Authorize (Roles ="Reader")]

        public async Task<IActionResult> Get()
        {
            try
            {
                throw new Exception("Its me");
           loger.LogInformation("Get all Methods Invoked");
            //Get data from Database
            var ordersDomain = await repo.GetOrders();

            //Map Domain to DTO
          var orders =  mapper.Map<List<OrderDto>>(ordersDomain);

          loger.LogInformation($"Get orders invoked : {JsonSerializer.Serialize(orders)}");
            

            //Return DTO's

            return Ok(orders);

            }

            catch (Exception ex)
            {
                return BadRequest( ex.Message);
            }
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById(int id)
        {
            var orders = await repo.GetOrderById(id);
            return Ok(orders);

        }

        [HttpPost]
       // [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddOrderDto dto)
        {
            //Get data from Domain Model

            //  var orderDomain= (await repo.CreateOrder(orders));

            //Map Domain Models to Dto
            /*
            var orderDomainModel = new OrdersModel
            {
                CustomerId = dto.CustomerId,
                CustomerName = dto.CustomerName,
                CustomerEmail = dto.CustomerEmail,
                CustomerPhone = dto.CustomerPhone,
                address = dto.address,
                Bill = dto.Bill,
                CustomerCity = dto.CustomerCity
            };
            */



            //Use DomainModel to Create Order

            //db.OrdersDM.Add(orderDomainModel);
            //db.SaveChanges();

            //Map domain model back to Dto
            //var Orderdto = new OrderDto
            //{
            //    CustomerId = orderDomainModel.CustomerId,
            //    CustomerName = orderDomainModel.CustomerName,
            //    CustomerEmail = orderDomainModel.CustomerEmail,
            //    CustomerPhone = orderDomainModel.CustomerPhone,
            //    address = orderDomainModel.address,
            //    Bill = orderDomainModel.Bill


            //};
            // return Ok(orderDomainModel);
            //Map Dto to Domain

            var Domain = mapper.Map<OrdersModel>(dto);

            //Use Domain to Create Order
            Domain = await repo.CreateOrder(Domain);

            //Domain to dto
            var Orderdto = mapper.Map<OrderDto>(Domain);   

            return CreatedAtAction(nameof(Create), new { OrderId = Orderdto.OrderId }, Orderdto);

        }

        [HttpPut("{id}")]
    //    [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] UpdateOrderDto orders)
        {
            //Check If Order Exists or Not 
            var DomainModel = await db.OrdersDM.FirstOrDefaultAsync(x => x.OrderId == id);
            if (DomainModel == null)
            {
                return NotFound(id);
            }
            /*
            //Mappping Dto to DomainModel using AutoMapper

          //  var Domain = mapper.Map<OrdersModel>(orders);


            DomainModel = await repo.UpdateOrder(id, DomainModel);
            if(DomainModel != null)
            {
                return NotFound();
            }

            //Convert Domain to dto
            var Orderdto = mapper.Map<OrderDto>(DomainModel);

            return Ok(Orderdto);
            */

            //Map Dto to DomainModel
            DomainModel.CustomerName = orders.CustomerName;
            DomainModel.address = orders.address;
            DomainModel.CustomerEmail = orders.CustomerEmail;
            DomainModel.CustomerPhone = orders.CustomerPhone;

            //Convert Domain to Dto
            var Orderdto = new OrderDto
            {
                CustomerPhone = orders.CustomerPhone,
                CustomerName = orders.CustomerName,
                CustomerEmail = orders.CustomerEmail,
                address = orders.address,
            };


            db.SaveChangesAsync();
            return Ok(Orderdto);

            // await repo.UpdateOrder(id, orders);  
            //db.SaveChanges();   
            //return Ok("Successfully updated😅");
            /*
            
             var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id ==id);

            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return existingRegion;

             */

        }

        [HttpDelete("{id}")]
    //    [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var domainOrder = await db.OrdersDM.FirstOrDefaultAsync(x => x.OrderId == id);
            if (domainOrder == null) 
            { 
                return NotFound(id);
            }

            //Delete Order
            db.OrdersDM.Remove(domainOrder);
           // db.SaveChanges();

            //To return deleted order in Output

            //Map Domain model to DTO

            var orderdto = new OrderDto
            {
                OrderId = domainOrder.OrderId,
                CustomerName = domainOrder.CustomerName,
                CustomerEmail = domainOrder.CustomerEmail,
                CustomerCity = domainOrder.CustomerCity,
                CustomerId = domainOrder.CustomerId,
                CustomerPhone = domainOrder.CustomerPhone,

            };

            db.SaveChangesAsync();

            return Ok(orderdto);
        }

    }
}
