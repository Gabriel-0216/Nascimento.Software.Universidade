using Microsoft.EntityFrameworkCore;
using Nascimento.Software.Universidade.Domain.Models.University.Registration;
using Nascimento.Software.Universidade.Infra.Context;
using Nascimento.Software.Universidade.Infra.Processment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Infra.Processment.Classes
{
    public class CourseDisciplineRegister : ICourseDiscipline
    {
        private readonly ApplicationDbContext _context;
        public CourseDisciplineRegister(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Course_Disciplines>> GetAll()
        {
            try
            {
                return await _context.Courses_Disciplines.AsNoTracking().
                    Include(p => p.Discipline)
                    .Include(d => d.Course)
                    .ToListAsync();

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Course_Disciplines>> GetDisciplinesByCourse(int CourseId)
        {
            try
            {
                return await _context.Courses_Disciplines
                    .Where(p => p.CourseId == CourseId)
                    .Include(d => d.Discipline)
                    .AsNoTracking().ToListAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> Start(Course_Disciplines course_Disciplines)
        {
            try
            {
                if (!await Validations(course_Disciplines))
                {
                    return false;
                }
                if (await RegisterDisciplineCourse(course_Disciplines))
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }

        private async Task<bool> Validations(Course_Disciplines course_Disciplines)
        {
            try
            {
                var course = await _context.Courses_Disciplines.Where(p => p.CourseId == course_Disciplines.CourseId).ToListAsync();
                var discipline = await _context.Courses_Disciplines.Where(d => d.DisciplineId == course_Disciplines.DisciplineId).ToListAsync();
                if (course == null || discipline == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        private async Task<bool> RegisterDisciplineCourse(Course_Disciplines course_Disciplines)
        {
            try
            {
                _context.Add(course_Disciplines);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Course_Disciplines>> GetCoursesByDiscipline(int DisciplineId)
        {
            return await _context.Courses_Disciplines.
                Where(p => p.DisciplineId == DisciplineId)
                .Include(d => d.Course)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
