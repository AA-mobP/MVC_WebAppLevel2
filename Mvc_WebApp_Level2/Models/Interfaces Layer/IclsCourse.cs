namespace Mvc_WebApp_Level2.Models.Interfaces_Layer
{
    public interface IclsCourse
    {
        List<Course> GetAll();
        Course GetOne(int id);
        int? GetPreviousId();
        int? GetNextId();
        Course? Find(int id);
        void Add(Course course);
        void Edit(Course course);
        void Delete(int id);
        List<Course> GetRelative(int deptId);
    }
}
