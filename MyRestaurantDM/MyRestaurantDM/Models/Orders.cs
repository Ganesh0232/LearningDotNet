namespace MyRestaurantDM.Models
{
    public class Orders
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }

        public string? CustomerEmail { get; set; }
        
        public string? CustomerPhone { get; set;}


        public string? CustomerCity { get; set;}

        public string? address { get; set; }

        public int? Bill { get; set; }

    


    }
}
