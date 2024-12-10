namespace Mvc_WebApp_Level2.Models.Interfaces_Layer
{
    public interface IclsInstructor
    {
        List<Instructor> GetAll();
        Instructor GetOne(int id);
        int? GetPreviousId();
        int? GetNextId();
        Instructor? Find(int id);
        void Add(Instructor instructor);
        void Edit(Instructor instructor);
        void Delete(int id);
        List<Instructor> GetRelativeToDepartment(int deptId);
    }
}
