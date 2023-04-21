using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyRestaurantDM.Data;
using MyRestaurantDM.Models;
using System.Data.Common;

namespace MyRestaurantDM.Repositories
{
    public class ItemRepo : IItemRepo
    {
     //   private DbConnection dbConnection;
        private readonly MyRestaurantDbContext dbC;

        public ItemRepo(MyRestaurantDbContext dbC)
        {
            this.dbC = dbC;
        }
        public async Task<ItemModel> CreateItem(ItemModel items)
        {
          await dbC.ItemsDM.AddAsync(items);
            await dbC.SaveChangesAsync();
            return items;

        }

        public async Task<ItemModel> DeleteItem(int id)
        {
          var items = await dbC.ItemsDM.FirstOrDefaultAsync(x =>x.ItemId ==id );  
            if (items == null)
            {
                return null;
            }
         var item= dbC.ItemsDM.Remove(items);
            await dbC.SaveChangesAsync();


            return items;
        }

        public async Task<List<ItemModel>> GetItems()
        {
           var items = await dbC.ItemsDM.ToListAsync();
            return items;
        }

        public async Task<ItemModel> GetItemsByID(int id)
        {
            var item = await dbC.ItemsDM.FirstOrDefaultAsync(x=>x.ItemId ==id);
            return item;
        }

        public async Task<ItemModel> UpdateItem(int id, ItemModel item)
        {
            var itemneedToUpdate=dbC.ItemsDM.FirstOrDefault(x=>x.ItemId ==id);
            if (itemneedToUpdate == null)
            {
                return null;
            }

            itemneedToUpdate.ItemCount=item.ItemCount;
            itemneedToUpdate.ItemPrice = item.ItemPrice;
            itemneedToUpdate.ItemName = item.ItemName;

            await dbC.SaveChangesAsync();
            return itemneedToUpdate;

            
        }
    }
}
