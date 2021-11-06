using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nascimento.Software.Universidade.Domain.Models.University.StudentCourseRegister;

namespace NascimentoSoftware.Universidade.Infra.Processment
{
    public interface IStudentCourseRegister
    {
        //receber o curso e o aluno que está sendo matrículado
        Task<bool> Start(StudentCourse student);

        Task<IEnumerable<StudentCourse>> Get();

    }

}