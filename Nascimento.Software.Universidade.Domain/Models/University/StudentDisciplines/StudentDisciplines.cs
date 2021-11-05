using System;
using System.Collections.Generic;
using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using Nascimento.Software.Universidade.Domain.Models.University.Disciplines;

namespace Nascimento.Software.Universidade.Domain.Models.University
{
    public class StudentDisciplines
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public IEnumerable<Discipline> Disciplines { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now.Date;
        public Guid RegisterToken { get; set; } = Guid.NewGuid();
    }
}