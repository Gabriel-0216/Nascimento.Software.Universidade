using Nascimento.Software.Universidade.Application.Services.Contratos;
using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using Nascimento.Software.Universidade.Domain.Models.University.Courses;
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
        private readonly ICommomService<Student> _studentRegister;
        private readonly ICommomService<Course> _courseRegister;
        public AcademicService(IStudentCourseRegister register,
            ICommomService<Student> studentRegister,
            ICommomService<Course> courseRegister)
        {
            _studentRegister = studentRegister;
            _courseRegister = courseRegister;
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
                //Verificar se o curso e o aluno existem
                var course = await _courseRegister.Get(student.CourseId);
                if (course == null)
                {
                    throw new Exception("Curso não existe");
                }
                var studentGet = await _studentRegister.Get(student.StudentId);
                if (studentGet == null) throw new Exception("aluno não existe");

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
