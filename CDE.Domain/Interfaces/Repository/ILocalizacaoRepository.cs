using CDE.Domain.Entities;
using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Repository
{
    public interface ILocalizacaoRepository: IBaseRepository<Localizacao>
    {
        Task<Localizacao> ListarTodos();
    }
}
