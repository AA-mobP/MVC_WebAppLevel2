using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_WebApp_Level2.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }

        [ForeignKey("tblCourse")]
        public int CourseId { get; set; }
        public Course tblCourse { get; }

        
        [ForeignKey("tblTrainee")]
        public int TraineeId { get; set; }
        public Trainee tblTrainee { get; }
    }
}
