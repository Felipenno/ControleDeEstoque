using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public void Deletar(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
        }

        public async Task<Usuario> PegarPorId(int id)
        {
            return await _context.Usuarios.Where(x => x.UsuarioId == id).FirstOrDefaultAsync();
        }

        public void SalvarAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
