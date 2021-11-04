using Microsoft.EntityFrameworkCore;
using Nascimento.Software.Universidade.Domain.Models.Person.Teacher;
using Nascimento.Software.Universidade.Infra.Context;
using Nascimento.Software.Universidade.Infra.Repositorys.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Infra.Repositorys.Repository
{
    public class TeacherDAO : ICommomDAO<Teacher>
    {
        private readonly ApplicationDbContext _context;
        public TeacherDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Teacher entity)
        {
            try
            {
                _context.teachers.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }catch(Exception e)
            {
                //logg e.message
                return false;
            }

        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = _context.teachers.FirstOrDefault<Teacher>(p => p.Id == id);
                if(entity != null)
                {
                    _context.teachers.Remove(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }catch(Exception e)
            {
                return false;
            }

            return false;
        }

        public async Task<IEnumerable<Teacher>> Get()
        {
            try
            {
                IQueryable<Teacher> query = _context.teachers.Include(p => p.Address).Include(p => p.Phone);

                query = query.AsNoTracking().OrderBy(m => m.Id);
                return await query.ToListAsync();
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public async Task<Teacher> GetOne(int id)
        {
            try
            {
                return await _context.teachers.FirstOrDefaultAsync(p => p.Id == id);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Teacher entity)
        {
            try
            {
                _context.teachers.Update(entity);
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
