using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nascimento.Software.Universidade.Domain.Models.Person.Shared;
using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using Nascimento.Software.Universidade.Domain.Models.Person.Teacher;
using Nascimento.Software.Universidade.Domain.Models.University.CollegeYear;
using Nascimento.Software.Universidade.Domain.Models.University.Courses;
using Nascimento.Software.Universidade.Domain.Models.University.Disciplines;
using Nascimento.Software.Universidade.Domain.Models.University.Registration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options) { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course_Disciplines>().HasKey(PE => new { PE.CourseId, PE.DisciplineId });
        }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Course_Disciplines> Courses_Disciplines { get; set; }
        public DbSet<TermTime> LectiveYears { get; set; }

    }
}
