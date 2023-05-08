using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UserStories.Models
{
    public class RegisterModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [StringLength(32)]
        public string LastName { get; set; }= string.Empty;
        [Required]
        [StringLength(32)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }=string.Empty;
        [Required]
        [DataType(DataType.PhoneNumber)]
        public long phoneNumber { get; set; }

        

    }
}
