using System.ComponentModel.DataAnnotations;

namespace Mvc_WebApp_Level2.Models.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public int Grade { get; set; }
    }
}
