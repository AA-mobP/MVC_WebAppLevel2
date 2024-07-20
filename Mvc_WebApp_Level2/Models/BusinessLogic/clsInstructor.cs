using Mvc_WebApp_Level2.Models.Interfaces_Layer;
using System.Runtime.InteropServices;

namespace Mvc_WebApp_Level2.Models.BusinessLogic
{
    public class clsInstructor : IclsInstructor
    {
        private AppDbContext context;
        private List<Instructor> instructors;
        int index;

        public int next {get; private set;}
        public int previous { get; private set;}

        public clsInstructor()
        {
            context = new AppDbContext();
            instructors = context.instructors.ToList();
        }

        public List<Instructor> GetAll()
        {
            return instructors;
        }

        public Instructor GetOne(int id)
        {
            index = instructors.FindIndex(m => m.Id == id);
            if (index != -1)
                return instructors[index];
            return new Instructor();
        }

        public int? GetPreviousId()
        {
            if (index > 0)
                return instructors[index - 1].Id;
            return null;
        }

        public int? GetNextId()
        {
            if (index < instructors.Count - 1)
                return instructors[index + 1].Id;
            return null;
        }

        public Instructor? Find(int id) => context.instructors.FirstOrDefault(i => i.Id == id);

        public void Add(Instructor instructor)
        {
            context.instructors.Add(instructor);
            context.SaveChanges();
        }

        public void Edit(Instructor instructor)
        {
            Instructor? OldInstructor = Find(instructor.Id);
            if (OldInstructor != null)
            {
                OldInstructor.Name = instructor.Name;
                OldInstructor.Address = instructor.Address;
                OldInstructor.Image = instructor.Image;
                OldInstructor.Salary = instructor.Salary;
                OldInstructor.DeptId = instructor.DeptId;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Instructor? instructor = Find(id);
            if (instructor != null)
            {
                context.instructors.Remove(instructor);
                context.SaveChanges();
            }
        }

        public List<Instructor> GetRelativeToDepartment(int deptId)
        {
            return context.instructors.Where(m => m.DeptId == deptId).ToList();
        }
    }
}
