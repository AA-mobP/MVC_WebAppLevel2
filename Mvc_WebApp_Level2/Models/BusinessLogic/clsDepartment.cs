namespace Mvc_WebApp_Level2.Models.BusinessLogic
{
    public class clsDepartment
    {
        private static AppDbContext context = new AppDbContext();
        private static List<Department> departments = context.departments.ToList();
        int index;

        public List<Department> GetAll()
        {
            return departments;
        }

        public Department GetOne(int id)
        {
            index = departments.ToList().FindIndex(d => d.Id == id);
            if (index != -1)
                return departments[index];
            return new Department();
        }

        public int? GetPreviousId()
        {
            if (index > 0)
                return departments[index - 1].Id;
            return null;
        }

        public int? GetNextId()
        {
            if (index < departments.Count - 1)
                return departments[index + 1].Id;
            return null;
        }

        public Department? Find(int id) => context.departments.FirstOrDefault(d => d.Id == id);

        public void Add(Department department)
        {
            context.departments.Add(department);
            context.SaveChanges();
        }

        public void Edit(Department department)
        {
            Department? OldDepartment = Find(department.Id);
            if (OldDepartment != null)
            {
                OldDepartment.Name = department.Name;
                OldDepartment.Manager = department.Manager;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Department? department = Find(id);
            if (department != null)
            {
                context.departments.Remove(department);
                context.SaveChanges();
            }
        }
    }
}
