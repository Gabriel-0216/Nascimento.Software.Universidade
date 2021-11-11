using Nascimento.Software.Universidade.Domain.Models.University.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Application.Services.AcademicRegistration
{
    public interface ICourseDisciplineService
    {
        Task<IEnumerable<Course_Disciplines>> GetAll();
        Task<IEnumerable<Course_Disciplines>> GetDisciplinesByCourse(int CourseId);
        Task<IEnumerable<Course_Disciplines>> GetCoursesByDiscipline(int DisciplineId);
        Task<bool> Start(Course_Disciplines course_Disciplines);
    }
}
