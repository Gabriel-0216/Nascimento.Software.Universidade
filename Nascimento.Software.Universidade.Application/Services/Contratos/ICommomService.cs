using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Application.Services.Contratos
{
   public interface ICommomService<T>
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();

    }
}
