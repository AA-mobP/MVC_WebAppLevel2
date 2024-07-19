using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Mvc_WebApp_Level2.Models
{
    public class Trainee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(25)]
        public string Image { get; set; }

        [Required]
        [MaxLength(50)]
        public string address { get; set; }

        [Required]
        [Range(1, 4)]
        public int Grade { get; set; }

        [Required]
        [Range (1, 5000)]
        [ForeignKey("tblDepartment")]
        public int DeptId { get; set; }
        [ValidateNever]
        public Department tblDepartment { get; set; }
        [ValidateNever]
        public ICollection<CourseResult> CoursesResult { get; set; }
    }
}
