using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Domain.Models.Person.Shared
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public Phone Phone { get; set; }
        public DateTime Created_At { get; set; } = DateTime.Now.Date;
        public DateTime? Updatet_At { get; set; } = DateTime.Now.Date;

    }
}
