using System;

namespace Nascimento.Software.Universidade.Domain.Models.Person.Teacher
{
    public class Teacher : Person.Shared.Person
    {
        public Teacher()
        {
            Identification = new Guid();
        }
        public Guid Identification { get; set; }

    }
}
