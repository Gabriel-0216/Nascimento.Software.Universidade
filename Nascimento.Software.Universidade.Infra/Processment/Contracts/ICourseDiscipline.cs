using Nascimento.Software.Universidade.Domain.Models.University.Registration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Infra.Processment.Contracts
{
    public interface ICourseDiscipline
    {
        Task<IEnumerable<Course_Disciplines>> GetAll();
        Task<IEnumerable<Course_Disciplines>> GetDisciplinesByCourse(int CourseId);
        Task<IEnumerable<Course_Disciplines>> GetCoursesByDiscipline(int DisciplineId);
        Task<bool> Start(Course_Disciplines course_Disciplines);
    }
}
