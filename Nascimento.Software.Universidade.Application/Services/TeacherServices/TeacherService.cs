using Nascimento.Software.Universidade.Application.Services.Contratos;
using Nascimento.Software.Universidade.Domain.Models.Person.Teacher;
using Nascimento.Software.Universidade.Infra.Repositorys.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Application.Services.TeacherServices
{
    public class TeacherService : ICommomService<Teacher>
    {
        private readonly ICommomDAO<Teacher> _commom;
        public TeacherService(ICommomDAO<Teacher> commom)
        {
            _commom = commom;
        }
        public async Task<bool> Add(Teacher entity)
        {
            try
            {
                await _commom.Add(entity);
                return true;

            }catch(Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _commom.Delete(id);
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public async Task<Teacher> Get(int id)
        {
            try
            {
                var retorno = await _commom.GetOne(id);
                if(retorno != null)
                {
                    return retorno;
                }
                return null;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            try
            {
                var retorno = await _commom.Get();
                return retorno;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public async Task<bool> Update(Teacher entity)
        {
            try
            {
                await _commom.Update(entity);
                return true;

            }catch(Exception e)
            {
                return false;
            }
        }
    }
}
