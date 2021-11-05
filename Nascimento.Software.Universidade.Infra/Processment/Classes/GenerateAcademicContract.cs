using System.Collections.Generic;
using System.Threading.Tasks;
using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using Nascimento.Software.Universidade.Domain.Models.University.Courses;
using Nascimento.Software.Universidade.Domain.Models.University.Disciplines;

namespace NascimentoSoftware.Universidade.Infra.Processment
{

    public class GenerateAcademicContract : IAcademicContract
    {
    
        private async Task<bool> RegisterStudentCourse(Student studentEntity, Course course)
        {
            // gerar um registro na tabela StudentCourse pra Aluno -> Curso
            // 1 para 1
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
            //Método que será chamado pra realizar o processo 
            await RegisterStudentCourse(studentEntity, course);
            
            // pegar todas as disciplinas daquele curso, colocar numa lista e passar 
            // pro register student disciplines
            

            throw new System.NotImplementedException();
        }
    }

}