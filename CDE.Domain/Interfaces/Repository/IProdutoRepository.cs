using CDE.Domain.Entities;
using CDE.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<List<ListarProdutosViewModel>> ListarTodosAsync();
        Task<Produto> EncontrarPorNomeAsync(string produtoNome);
    }
}
