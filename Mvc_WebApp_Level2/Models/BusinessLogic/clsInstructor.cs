using System.Runtime.InteropServices;

namespace Mvc_WebApp_Level2.Models.BusinessLogic
{
    public class clsInstructor
    {
        
        List<Instructor> models;
        Instructor? model;
        public int next {get; private set;}
        public int previous { get; private set;}

        public clsInstructor()
        {
            models = new AppDbContext().instructors.ToList();
            model = new Instructor();
        }

        public List<Instructor> GetAllInstructors()
        {
            return models;
        }

        public Instructor GetInstructor(int id)
        {
            int index = models.FindIndex(x => x.Id == id);
            
            if (index != -1)
                return models[index];
            
            return new Instructor();
        }

        public int GetIndex(int id)
        {
            return models.FindIndex(m => m.Id == id);
        }

        //There's a Probability of OutOfRange Exception but now i'll suppose the rightness of the argument
        public int? GetNext(int id)
        {
            int NextIndex = models.FindIndex(m => m.Id == id) + 1;
            if (NextIndex < models.Count)
                return models[NextIndex].Id;
            return null;
        }

        public int? GetPrevious(int id)
        {
            int PreviousIndex = models.FindIndex(m => m.Id == id) - 1;
            if (PreviousIndex >= 0)
                return models[PreviousIndex].Id;
            return null;
        }

    }
}
