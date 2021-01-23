using CDE.Domain.Entities;
using CDE.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Repository
{
    public interface ILocalizacaoRepository : IBaseRepository<Localizacao>
    {
        Task<List<ListarLocalizacoesViewModel>> ListarTodosAsync();
    }
}
