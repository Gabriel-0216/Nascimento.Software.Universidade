using Nascimento.Software.Universidade.Domain.Models.University.StudentCourseRegister;
using NascimentoSoftware.Universidade.Infra.Processment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Application.Services.AcademicRegistration
{
    public class AcademicService : IAcademicService
    {
        private readonly IStudentCourseRegister _register;
        public AcademicService(IStudentCourseRegister register)
        {
            _register = register;
        }
        public async Task<IEnumerable<StudentCourse>> Get()
        {
            try
            {
                return await _register.Get();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> Start(StudentCourse student)
        {
            try
            {
                if (await _register.Start(student))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}
