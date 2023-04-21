using Microsoft.AspNetCore.Mvc;
using MyRestaurantDM.Models;
namespace MyRestaurantDM.Repositories

{
    public interface IItemRepo
    {
        Task<List<ItemModel>> GetItems();

        Task<ItemModel> GetItemsByID(int id);

        Task<ItemModel> CreateItem(ItemModel items);

        Task<ItemModel> UpdateItem(int id, ItemModel item);

        Task<ItemModel> DeleteItem(int id);
    }
}
