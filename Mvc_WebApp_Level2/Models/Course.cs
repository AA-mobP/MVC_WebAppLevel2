using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_WebApp_Level2.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [Range(25, 150)]
        public int MinDegree { get; set; }

        [Required]
        [Range(50, 200)]
        public int MaxDegree { get; set; }

        [Required]
        [Range(1, 5000)]
        [ForeignKey("tblDepartment")]
        public int DeptId { get; set; }
        [ValidateNever]
        public Department tblDepartment { get; set; }

        [Required]
        [Range(1, 5000)]
        [ForeignKey("tblInstructor")]
        public int IctorId { get; set; }
        [ValidateNever]
        public Instructor tblInstructor { get; set; }

        [ValidateNever]
        public ICollection<CourseResult> CoursesResult { get; set; }
    }
}
