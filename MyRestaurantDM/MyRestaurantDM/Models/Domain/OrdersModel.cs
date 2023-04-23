using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyRestaurantDM.Models.Domain
{
    public class OrdersModel
    {
        [Key]
        public int OrderId { get; set; }

        [Required, Unicode]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }

        public string? CustomerEmail { get; set; }

        public string? CustomerPhone { get; set; }


        public string? CustomerCity { get; set; }

        public string? address { get; set; }

        public int? Bill { get; set; }




    }
}
