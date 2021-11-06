namespace Nascimento.Software.Universidade.Domain.Models.University.Courses
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CollegeYearId { get; set; }
        public CollegeYear.TermTime CollegeYear { get; set; }


    }
}
