using Microsoft.EntityFrameworkCore;
using Nascimento.Software.Universidade.Domain.Models.University.Disciplines;
using Nascimento.Software.Universidade.Infra.Context;
using Nascimento.Software.Universidade.Infra.Repositorys.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Infra.Repositorys.Repository
{
    public class DisciplinesDAO : ICommomDAO<Discipline>
    {
        private readonly ApplicationDbContext _context;
        public DisciplinesDAO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Discipline entity)
        {
            try
            {
                _context.Disciplines.Add(entity);
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
                var entity = await _context.Disciplines.FirstAsync(p => p.Id == id);
                _context.Disciplines.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Discipline>> Get()
        {
            try
            {
                IQueryable<Discipline> query = _context.Disciplines.Include(p => p.CollegeYear);

                query = query.AsNoTracking();
                query = query.OrderBy(p => p.Id);
                return await query.ToListAsync();

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Discipline> GetOne(int id)
        {
            try
            {
                IQueryable<Discipline> query = _context.Disciplines.Include(p => p.CollegeYear);
                query = query.AsNoTracking();
                var entity = query.First(p => p.Id == id);
                if (entity != null)
                {
                    return entity;
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Discipline entity)
        {
            try
            {
                _context.Disciplines.Update(entity);
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
