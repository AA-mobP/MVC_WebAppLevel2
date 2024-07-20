using Mvc_WebApp_Level2.Models.ViewModels;

namespace Mvc_WebApp_Level2.Models.Interfaces_Layer
{
    public interface IclsTrainee
    {
        List<Trainee> GetAll();
        stdName_stdDegree_crsName? GetOne(int id);
        int? GetPreviousId();
        int? GetNextId();
        void Add(Trainee trainee);
        Trainee? Find(int id);
        void Edit(Trainee arg);
        void Delete(int id);
        List<Trainee> GetRelativeDataToDepartment(int deptId);
    }
}
