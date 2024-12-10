namespace Mvc_WebApp_Level2.Models.Interfaces_Layer
{
    public interface IclsDepartment
    {
        List<Department> GetAll();
        Department GetOne(int id);
        int? GetPreviousId();
        int? GetNextId();
        Department? Find(int id);
        void Add(Department department);
        void Edit(Department department);
        void Delete(int id);
    }
}
