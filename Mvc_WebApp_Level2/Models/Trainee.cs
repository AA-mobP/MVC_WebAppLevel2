using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_WebApp_Level2.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string address { get; set; }
        public int Grade { get; set; }

        [ForeignKey("tblDepartment")]
        public int DeptId { get; set; }
        public Department tblDepartment { get; set; }

        public ICollection<CourseResult> CoursesResult { get; set; }
    }
}
