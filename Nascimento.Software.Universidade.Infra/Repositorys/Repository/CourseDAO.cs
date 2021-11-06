using Microsoft.EntityFrameworkCore;
using Nascimento.Software.Universidade.Domain.Models.University.Courses;
using Nascimento.Software.Universidade.Infra.Context;
using Nascimento.Software.Universidade.Infra.Repositorys.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Infra.Repositorys.Repository
{
    public class CourseDAO : ICommomDAO<Course>
    {
        private readonly ApplicationDbContext _context;
        public CourseDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Course entity)
        {
            try
            {
                _context.Courses.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = _context.Courses.First(p => p.Id == id);
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Course>> Get()
        {
            try
            {
                IQueryable<Course> query = _context.Courses.Include(p => p.CollegeYear);
                query = query.OrderBy(p => p.Id).AsNoTracking();
                return await query.ToListAsync();

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Course> GetOne(int id)
        {
            try
            {
                IQueryable<Course> query = _context.Courses.Include(p => p.CollegeYear);
                return await query.FirstAsync(p => p.Id == id);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Course entity)
        {
            try
            {
                _context.Courses.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
