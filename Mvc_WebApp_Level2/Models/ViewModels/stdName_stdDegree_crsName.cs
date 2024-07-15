namespace Mvc_WebApp_Level2.Models.ViewModels
{
    public class stdName_stdDegree_crsName
    {
        public string StudentName { get; set; }
        public List<string> CourseNames { get; set; }
        public List<int> StudentDegrees { get; set; }
        public List<int> MinDegrees { get; set; }
    }
}
