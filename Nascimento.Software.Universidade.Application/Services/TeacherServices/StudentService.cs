using Nascimento.Software.Universidade.Application.Services.Contratos;
using Nascimento.Software.Universidade.Domain.Models.Person.Student;
using Nascimento.Software.Universidade.Infra.Repositorys.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Application.Services.TeacherServices
{
    public class StudentService : ICommomService<Student>
    {
        private readonly ICommomDAO<Student> _commom;
        public StudentService(ICommomDAO<Student> commom)
        {
            _commom = commom;
        }
        public async Task<bool> Add(Student entity)
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

        public async Task<Student> Get(int id)
        {
            try
            {
                var entity = await _commom.GetOne(id);
                if (entity == null)
                {
                    throw new Exception("Ocorreu um erro, o curso não existe");
                }
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<IEnumerable<Student>> GetAll()
        {
            try
            {
                var list = _commom.Get();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<bool> Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
