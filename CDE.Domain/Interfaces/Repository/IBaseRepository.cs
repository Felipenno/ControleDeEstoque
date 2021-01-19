using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Deletar(T entity);
        void SalvarAsync();
        Task<T> PegarPorId(int id);
    }
}
