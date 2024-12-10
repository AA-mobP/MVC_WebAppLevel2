using Microsoft.EntityFrameworkCore;
using Mvc_WebApp_Level2.Models.ViewModels;
using Mvc_WebApp_Level2.Models;
using System.Linq;
using Mvc_WebApp_Level2.Models.Interfaces_Layer;

namespace Mvc_WebApp_Level2.Models.BusinessLogic
{
    public class clsTrainee : IclsTrainee
    {
        private AppDbContext context;
        private List<Trainee> trainees;
        private int index;

        public clsTrainee(AppDbContext _context)
        {
            context = _context;
            trainees = context.trainees.ToList();
        }

        public List<Trainee> GetAll() => trainees;

        public stdName_stdDegree_crsName? GetOne(int id)
        {
            var v1 = context.trainees.FirstOrDefault(x => x.Id == id)?.Name;//Get Student Name
            var v2 = context.coursesResult.Where(x => x.TraineeId == id).ToList();//Get List<CourseResult>
            var arr = v2.Select(m => m.CourseId).ToList();//Get List<int> Courses Ids
            var v3 = context.courses.Where(m => arr.Contains(m.Id)).ToList();//Get Courses

            stdName_stdDegree_crsName res = new stdName_stdDegree_crsName();

            res.StudentName = v1;
            res.StudentDegrees = v2.Select(m => m.Degree).ToList();
            res.CourseNames = v3.Select(m => m.Name).ToList();
            res.MinDegrees = v3.Select(m => m.MinDegree).ToList();

            index = trainees.FindIndex(t => t.Id == id);
            if (index != -1)
                return res;
            return new stdName_stdDegree_crsName();
        }

        public int? GetPreviousId()
        {
            if (index > 0)
                return trainees[index - 1].Id;
            return null;
        }

        public int? GetNextId()
        {
            if (index < trainees.Count - 1)
                return trainees[index + 1].Id;
            return null;
        }

        public void Add(Trainee trainee)
        {
            context.trainees.Add(trainee);
            context.SaveChanges();
        }

        public Trainee? Find(int id) =>
            context.trainees.FirstOrDefault(t => t.Id == id);

        public void Edit(Trainee arg)
        {
            var trainee = Find(arg.Id);
            if (trainee != null)
            {
                trainee.Name = arg.Name;
                trainee.address = arg.address;
                trainee.DeptId = arg.DeptId;
                trainee.Grade = arg.Grade;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Trainee? trainee = Find(id);
            if (trainee != null)
            {
                context.trainees.Remove(trainee);
                context.SaveChanges();
            }
        }

        public List<Trainee> GetRelativeDataToDepartment(int deptId)
        {
            return context.trainees.Where(t => t.DeptId == deptId).ToList();
        }
    }
}
