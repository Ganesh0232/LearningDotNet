using Microsoft.AspNetCore.Mvc;
using MyRestaurantDM.Models;
namespace MyRestaurantDM.Repositories

{
    public interface IItemRepo
    {
        Task<List<IActionResult>> GetItems();
    }
}
