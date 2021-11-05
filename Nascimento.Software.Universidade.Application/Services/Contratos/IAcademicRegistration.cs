using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using Nascimento.Software.Universidade.Domain.Models.University.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Application.Services.Contratos
{
    interface IAcademicRegistration
    {
        Task<bool> Start(Student studentEntity, Course course);
    }
}
