using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_WebApp_Level2.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinDegree { get; set; }

        [ForeignKey("tblDepartment")]
        public int DeptId { get; set; }
        public Department tblDepartment { get; set; }

        [ForeignKey("tblInstructor")]
        public int IctorId { get; set; }
        public Instructor tblInstructor { get; set; }

        public ICollection<CourseResult> CoursesResult { get; set; }
    }
}
