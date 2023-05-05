using System.ComponentModel.DataAnnotations;

namespace Logout.Models
{
    public class LoginModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
