using CDE.Domain.Entities;
using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<Produto> ListarTodos();
        Task<Produto> ListarPorDescricao();
    }
}
