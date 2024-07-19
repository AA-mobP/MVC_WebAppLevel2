using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mvc_WebApp_Level2.Models
{
    public class CourseResult
    {
        public int Id { get; set; }

        [Required]
        [Range(0, 200)]
        public int Degree { get; set; }

        [Required]
        [ForeignKey("tblCourse")]
        public int CourseId { get; set; }
        public Course tblCourse { get; }

        [Required]
        [ForeignKey("tblTrainee")]
        public int TraineeId { get; set; }
        [ValidateNever]
        public Trainee tblTrainee { get; }
    }
}
