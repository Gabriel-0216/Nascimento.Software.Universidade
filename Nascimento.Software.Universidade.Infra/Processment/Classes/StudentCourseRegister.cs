using Microsoft.EntityFrameworkCore;
using Nascimento.Software.Universidade.Domain.Models.University.StudentCourseRegister;
using Nascimento.Software.Universidade.Infra.Context;
using NascimentoSoftware.Universidade.Infra.Processment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Infra.Processment.Classes
{
    public class StudentCourseRegister : IStudentCourseRegister
    {
        public readonly ApplicationDbContext _context;
        public StudentCourseRegister(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentCourse>> Get()
        {
            try
            {
                IQueryable<StudentCourse> query = _context.StudentCourses
                     .Include(p => p.Course)
                     .Include(p => p.Student)
                     .Include(p => p.Student.Address)
                     .Include(p => p.Student.Phone)
                     .OrderBy(p => p.Id);

                var q = await query.ToListAsync();
                return q;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Start(StudentCourse student)
        {
            try
            {
                _context.StudentCourses.Add(student);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
