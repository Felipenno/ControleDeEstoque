using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CDE.Infra.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CDEContext _context;

        public UsuarioRepository(CDEContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Deletar(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public async Task<Usuario> EncontrarPorIdAsync(int id)
        {
            return await _context.Usuarios.Where(x => x.UsuarioId == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> EncontrarUsuarioAsync(string email)
        {
            return await _context.Usuarios.Where(x => x.UsuarioEmail == email).FirstOrDefaultAsync();
        }

        public async Task<Usuario> Logar(string email, string senha)
        {
            return await _context.Usuarios.Where(x => x.UsuarioEmail == email && x.UsuarioSenha == senha).FirstOrDefaultAsync();
        }

    }
}
