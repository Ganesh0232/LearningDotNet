using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace MyRestaurantDM.Models.Domain
{
    public class ItemModel
    {
        [Key]
        public int ItemId { get; set; }


        public string ItemName { get; set; }

        //    public int Count { get; set; }

        public int ItemCount { get; set; }

        public int ItemPrice { get; set; }

    }
}
