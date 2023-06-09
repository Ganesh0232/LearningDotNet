﻿using Microsoft.AspNetCore.Mvc;
using MyRestaurantDM.Data;
using MyRestaurantDM.Models.Domain;
using MyRestaurantDM.Repositories;
using System.Net;

namespace MyRestaurantDM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly MyRestaurantDbContext dm;

        private readonly IItemRepo repo;

        public ItemController(MyRestaurantDbContext dm, IItemRepo repo)
        {
            this.dm = dm;
            this.repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                throw new Exception("Hello , This is an intentional exception to check global" +
                    "Exception handling");

                var items = await repo.GetItems();
                return Ok(items);
            }
            catch (Exception ex)
            {

                return Problem("Something went wrong ", null, (int)HttpStatusCode.InternalServerError);

            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {


            var items = await repo.GetItemsByID(id);
            return Ok(items);



        }
        [HttpPost]

        public async Task<IActionResult> Create(ItemModel items)
        {

            await repo.CreateItem(items);
            dm.SaveChanges();

            return Ok(items);


        }

        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            var items = await repo.GetItems();

            var item = await repo.DeleteItem(id);
            dm.SaveChanges();

            return Ok(items);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, ItemModel item)
        {
            await repo.UpdateItem(id, item);
            dm.SaveChanges();

            return Ok("Updated Successfully😅");
        }


    }
}
