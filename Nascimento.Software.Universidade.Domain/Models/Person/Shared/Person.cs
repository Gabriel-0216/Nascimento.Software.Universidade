using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nascimento.Software.Universidade.Domain.Models.Person.Shared
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }

        [ForeignKey("PhoneId")]
        public virtual Phone Phone { get; set; }
        public int PhoneId { get; set; }

        public DateTime Created_At { get; set; } = DateTime.Now.Date;
        public DateTime? Updatet_At { get; set; } = DateTime.Now.Date;

    }
}
