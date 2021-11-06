namespace Nascimento.Software.Universidade.Domain.Models.University.Registration
{
    public class Course_Disciplines
    {
        public int DisciplineId { get; set; }
        public int CourseId { get; set; }
        public Courses.Course Course { get; set; }
        public Disciplines.Discipline Discipline { get; set; }

    }
}
