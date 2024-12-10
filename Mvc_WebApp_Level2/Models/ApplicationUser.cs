using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Mvc_WebApp_Level2.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string Branch { get; set; }
        public int Grade { get; set; }
    }
}
