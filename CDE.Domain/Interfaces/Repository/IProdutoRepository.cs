using CDE.Domain.Entities;
using CDE.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Repository
{
    public interface IProdutoRepository
    {
        void Adicionar(CriarProdutoViewModel novoProduto);
        void Atualizar(AtualizarProdutoViewModel atualizarProduto);
        Task<bool> Deletar(int id);
        Task<Produto> EncontrarPorIdAsync(int id);

        Task<List<ListarProdutosViewModel>> ListarTodosAsync();
        Task<Produto> EncontrarPorNomeAsync(string produtoNome);
    }
}
