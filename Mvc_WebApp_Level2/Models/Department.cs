using System.ComponentModel.DataAnnotations;

namespace Mvc_WebApp_Level2.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        public string Manager { get; set; }

    }
}
