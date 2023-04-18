using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models
{
    public class LoginViewModel
    {
        [Required]
        public  string Name { get; set; }

        public string CodeName { get; set; }
    }
}
