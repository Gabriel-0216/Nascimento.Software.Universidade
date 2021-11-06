using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nascimento.Software.Universidade.Infra.Repositorys.Contracts
{
    public interface ICommomDAO<T>
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<T>> Get();
        Task<T> GetOne(int id);

        Task<bool> SaveChangesAsync();
    }
}
