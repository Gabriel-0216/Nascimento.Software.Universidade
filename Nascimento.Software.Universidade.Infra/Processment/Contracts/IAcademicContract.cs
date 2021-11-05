using System.Collections.Generic;
using System.Threading.Tasks;
using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using Nascimento.Software.Universidade.Domain.Models.University.Courses;
using Nascimento.Software.Universidade.Domain.Models.University.Disciplines;

namespace NascimentoSoftware.Universidade.Infra.Processment
{
    public interface IAcademicContract
    {
        //receber o curso e o aluno que está sendo matrículado
        Task<bool> Start(Student studentEntity, Course course);

    }

}