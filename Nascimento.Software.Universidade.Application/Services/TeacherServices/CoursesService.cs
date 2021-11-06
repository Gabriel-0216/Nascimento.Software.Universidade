using Nascimento.Software.Universidade.Application.Services.Contratos;
using Nascimento.Software.Universidade.Domain.Models.University.Courses;
using Nascimento.Software.Universidade.Infra.Repositorys.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Application.Services.TeacherServices
{
    public class CoursesService : ICommomService<Course>
    {
        private readonly ICommomDAO<Course> _commom;
        public CoursesService(ICommomDAO<Course> commom)
        {
            _commom = commom;
        }
        public async Task<bool> Add(Course entity)
        {
            try
            {
                await _commom.Add(entity);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            try
            {
                return await _commom.Get();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Task<bool> Update(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
