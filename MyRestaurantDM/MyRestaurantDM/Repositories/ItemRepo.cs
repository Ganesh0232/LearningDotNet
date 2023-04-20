using Microsoft.AspNetCore.Mvc;

namespace MyRestaurantDM.Repositories
{
    public class ItemRepo : IItemRepo
    {
        public Task<List<IActionResult>> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
