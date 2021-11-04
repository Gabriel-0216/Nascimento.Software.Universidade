using Nascimento.Software.Universidade.Domain.Models.Person.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
