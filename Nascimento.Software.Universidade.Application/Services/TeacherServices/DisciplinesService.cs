using Nascimento.Software.Universidade.Application.Services.Contratos;
using Nascimento.Software.Universidade.Domain.Models.University.Disciplines;
using Nascimento.Software.Universidade.Infra.Repositorys.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Application.Services.TeacherServices
{
    public class DisciplinesService : ICommomService<Discipline>
    {
        private readonly ICommomDAO<Discipline> _commom;
        public DisciplinesService(ICommomDAO<Discipline> DAO)
        {
            _commom = DAO;
        }
        public async Task<bool> Add(Discipline entity)
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

        public Task<bool> Update(Discipline entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Discipline> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Discipline>> GetAll()
        {
            try
            {
                return _commom.Get();
            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}
