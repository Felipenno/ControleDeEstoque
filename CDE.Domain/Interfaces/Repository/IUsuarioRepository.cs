using CDE.Domain.Entities;
using System.Threading.Tasks;

namespace CDE.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        Task<Usuario> EncontrarUsuarioAsync(string email);
        Task<Usuario> Logar(string email, string senha);
    }
}
