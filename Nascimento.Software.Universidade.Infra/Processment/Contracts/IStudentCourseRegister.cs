using Nascimento.Software.Universidade.Domain.Models.University.StudentCourseRegister;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NascimentoSoftware.Universidade.Infra.Processment
{
    public interface IStudentCourseRegister
    {
        //receber o curso e o aluno que está sendo matrículado
        Task<bool> Start(StudentCourse student);

        Task<IEnumerable<StudentCourse>> Get();

    }

}