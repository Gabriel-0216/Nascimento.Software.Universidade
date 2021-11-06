using Microsoft.EntityFrameworkCore;
using Nascimento.Software.Universidade.Application.Services.Contratos;
using Nascimento.Software.Universidade.Domain.Models.University.CollegeYear;
using Nascimento.Software.Universidade.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Application.Services.TeacherServices
{
    public class CollegeYear : ICommomService<TermTime>
    {
        public ApplicationDbContext _context;

        public CollegeYear(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(TermTime entity)
        {
            try
            {
                _context.LectiveYears.Add(entity);
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
                var entity = await _context.FindAsync<TermTime>(id);
                _context.LectiveYears.Remove(entity);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<TermTime> Get(int id)
        {
            try
            {
                var entity = await _context.LectiveYears.FindAsync(id);
                if (entity != null)
                {
                    return entity;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<TermTime>> GetAll()
        {
            try
            {

                var entity = await _context.LectiveYears.OrderBy(p => p.Id).AsNoTracking().ToListAsync();
                if (entity != null)
                {
                    return entity;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> Update(TermTime entity)
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
