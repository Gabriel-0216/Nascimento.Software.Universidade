using Microsoft.EntityFrameworkCore;
using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using Nascimento.Software.Universidade.Infra.Context;
using Nascimento.Software.Universidade.Infra.Repositorys.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Infra.Repositorys.Repository
{
    public class StudentDAO : ICommomDAO<Student>
    {
        private readonly ApplicationDbContext _context;
        public StudentDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Student entity)
        {
            try
            {
                _context.Students.Add(entity);
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
                var entity = await _context.Students.FindAsync(id);
                _context.Students.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Student>> Get()
        {
            try
            {
                IQueryable<Student> query = _context.Students.Include(p => p.Address).Include(e => e.Phone);

                query = query.AsNoTracking();
                query = query.OrderBy(p => p.Id);

                return await query.ToListAsync();

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Student> GetOne(int id)
        {
            try
            {
                IQueryable<Student> query = _context.Students.Include(p => p.Address).Include(e => e.Phone);
                query = query.AsNoTracking();
                query = query.OrderBy(p => p.Id);

                return await query.FirstOrDefaultAsync(p => p.Id == id);
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

        public async Task<bool> Update(Student entity)
        {
            try
            {
                _context.Update(entity);
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
