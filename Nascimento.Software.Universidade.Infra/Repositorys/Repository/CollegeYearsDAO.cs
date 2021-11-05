using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nascimento.Software.Universidade.Domain.Models.University.CollegeYear;
using Nascimento.Software.Universidade.Infra.Context;
using Nascimento.Software.Universidade.Infra.Repositorys.Contracts;

namespace Nascimento.Software.Universidade.Infra.Repositorys.Repository
{
    public class CollegeYearsDAO : ICommomDAO<TermTime>
    {
        private readonly ApplicationDbContext _context;

        public CollegeYearsDAO(ApplicationDbContext context){
            _context = context;
        }
        public async Task<bool> Add(TermTime entity)
        {
            try
            {
                await _context.LectiveYears.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await _context.LectiveYears.FirstAsync(p=> p.Id == id);
                _context.LectiveYears.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<TermTime>> Get()
        {
            try
            {
                return await _context.LectiveYears.AsNoTracking().OrderBy(p=> p.Id).ToListAsync(); 
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public async Task<TermTime> GetOne(int id)
        {
            try
            {
                return await _context.LectiveYears.FirstAsync(p => p.Id == id);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Update(TermTime entity)
        {
            try
            {
                 _context.LectiveYears.Update(entity);
                 await _context.SaveChangesAsync();
                 return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}