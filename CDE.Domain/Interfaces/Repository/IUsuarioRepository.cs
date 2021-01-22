using CDE.Domain.Entities;
using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> EncontrarUsuarioAsync(string email);
        Task<Usuario> Logar(string nome, string senha);
    }
}
