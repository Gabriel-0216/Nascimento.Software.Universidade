using Nascimento.Software.Universidade.Application.Services.Contratos;
using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using Nascimento.Software.Universidade.Domain.Models.University.Courses;
using NascimentoSoftware.Universidade.Infra.Processment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Application.Services.AcademicRegistration
{
    public class StudentAcademicRegistration : IAcademicRegistration
    {
        private IAcademicContract _contract;

        public StudentAcademicRegistration(IAcademicContract contract)
        {
            _contract = contract;
        }
        public async Task<bool> Start(Student studentEntity, Course course)
        {
            try 
            { 
                if(studentEntity == null || course == null)
                {
                    return false;
                }
                await _contract.Start(studentEntity, course);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
