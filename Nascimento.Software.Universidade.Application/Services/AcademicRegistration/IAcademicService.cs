using Nascimento.Software.Universidade.Domain.Models.University.StudentCourseRegister;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Application.Services.AcademicRegistration
{
    public interface IAcademicService
    {
        Task<bool> Start(StudentCourse student);
        Task<IEnumerable<StudentCourse>> Get();
    }
}
