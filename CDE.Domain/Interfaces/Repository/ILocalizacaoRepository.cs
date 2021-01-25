using CDE.Domain.Entities;
using CDE.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Repository
{
    public interface ILocalizacaoRepository
    {
        void Adicionar(CriarLocalizacaoViewModel novoLocal);
        void Atualizar(AtualizarLocalizacaoViewModel atualizarLocal);
        Task<bool> Deletar(int id);
        Task<Localizacao> EncontrarPorIdAsync(int id);

        Task<List<ListarLocalizacoesViewModel>> ListarTodosAsync();
    }
}
