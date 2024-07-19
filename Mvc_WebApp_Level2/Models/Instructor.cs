using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_WebApp_Level2.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string Image { get; set; }

        [Required]
        [Range(1000, 50_000)]
        public int Salary { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [Range (1, 5000)]
        [ForeignKey("tblDepartment")]
        public int DeptId { get; set; }

        [ValidateNever]
        public Department tblDepartment { get; set; }
    }
}
