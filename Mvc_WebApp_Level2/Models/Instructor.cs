using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_WebApp_Level2.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }

        [ForeignKey("tblDepartment")]
        public int DeptId { get; set; }
        public Department tblDepartment { get; set; }
    }
}
