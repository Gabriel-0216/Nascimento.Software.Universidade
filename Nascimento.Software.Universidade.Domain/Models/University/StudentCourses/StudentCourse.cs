using System;
using System.ComponentModel;
using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using Nascimento.Software.Universidade.Domain.Models.University.Courses;

namespace Nascimento.Software.Universidade.Domain.Models.University
{

    public class StudentCourse
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now.Date;
        
        [ReadOnly(isReadOnly: true)]
        public Guid Ra { get; set; } = Guid.NewGuid();


    }
}