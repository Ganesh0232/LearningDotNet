using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyRestaurantDM.Models.DTO
{
    public class UpdateOrderDto
    {

        public int OrderId { get; set; }

       /// <summary>
       /// /[Required, Unicode]
       /// </summary>
       // public int CustomerId { get; set; }
        public string? CustomerName { get; set; }

        public string? CustomerEmail { get; set; }

        public string? CustomerPhone { get; set; }


        // public string? CustomerCity { get; set; }

        public string? address { get; set; }

     //   public int? Bill { get; set; }

    }
}
