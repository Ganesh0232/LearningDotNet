using System.ComponentModel.DataAnnotations;

namespace Asg_1_HotelBooking_AspMvc.Models
{
    public class HotelBooking
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string GuestName { get; set; }

        [Required]
        public DateTime DateStart { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }
        

    }
}
