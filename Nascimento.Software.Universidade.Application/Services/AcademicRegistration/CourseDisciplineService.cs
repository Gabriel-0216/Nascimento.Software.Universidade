using Nascimento.Software.Universidade.Domain.Models.University.Registration;
using Nascimento.Software.Universidade.Infra.Processment.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Application.Services.AcademicRegistration
{
    public class CourseDisciplineService : ICourseDisciplineService
    {
        private readonly ICourseDiscipline _infra;
        public CourseDisciplineService(ICourseDiscipline infra)
        {
            _infra = infra;
        }
        public async Task<IEnumerable<Course_Disciplines>> GetAll()
        {
            return await _infra.GetAll();
        }

        public async Task<IEnumerable<Course_Disciplines>> GetCoursesByDiscipline(int DisciplineId)
        {
            return await _infra.GetCoursesByDiscipline(DisciplineId);
        }

        public async Task<IEnumerable<Course_Disciplines>> GetDisciplinesByCourse(int CourseId)
        {
            return await _infra.GetDisciplinesByCourse(CourseId);
        }

        public async Task<bool> Start(Course_Disciplines course_Disciplines)
        {
            return await _infra.Start(course_Disciplines);
        }
    }
}
