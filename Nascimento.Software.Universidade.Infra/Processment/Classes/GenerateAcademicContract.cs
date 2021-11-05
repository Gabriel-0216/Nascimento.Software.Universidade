using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using Nascimento.Software.Universidade.Domain.Models.University;
using Nascimento.Software.Universidade.Domain.Models.University.Courses;
using Nascimento.Software.Universidade.Domain.Models.University.Disciplines;
using Nascimento.Software.Universidade.Infra.Context;

namespace NascimentoSoftware.Universidade.Infra.Processment
{

    public class GenerateAcademicContract : IAcademicContract
    {
        private ApplicationDbContext _context;
        private async Task<bool> RegisterStudentCourse(Student studentEntity, Course course)
        {
            try
            {
                var studentCourse = new StudentCourse()
                {
                    Course = course,
                    Student = studentEntity,
                    Created_At = System.DateTime.Today,
                    Ra = new System.Guid(),
                };

                _context.StudentCourse.Add(studentCourse);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            

            throw new System.NotImplementedException();
        }

        private async Task<bool> RegisterStudentDisciplines(Student studentEntity, IEnumerable<Discipline> disciplines)
        {
            //registrar um registro na tabela StudentDisciplines, cada disciplina é 
            //um registro
            throw new System.NotImplementedException();
        }

        public async Task<bool> Start(Student studentEntity, Course course)
        {
            var result = await RegisterStudentCourse(studentEntity, course);
            return result;
        }
    }

}