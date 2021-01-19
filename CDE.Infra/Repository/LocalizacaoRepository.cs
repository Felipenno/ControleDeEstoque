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
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly CDEContext _context;

        public LocalizacaoRepository(CDEContext context)
        {
            _context = context;
        }

        public void Adicionar(Localizacao localizacao)
        {
            _context.Localizacao.Add(localizacao);
        }

        public void Atualizar(Localizacao localizacao)
        {
            _context.Localizacao.Update(localizacao);
        }

        public void Deletar(Localizacao localizacao)
        {
            _context.Localizacao.Remove(localizacao);
        }

        public async Task<Localizacao> PegarPorId(int id)
        {
            return await _context.Localizacao.Where(x => x.LocalizacaoId == id).FirstOrDefaultAsync();
        }

        public async Task<Localizacao[]> ListarTodos()
        {
            return await _context.Localizacao.ToArrayAsync();
        }

        public void SalvarAsync()
        {
             _context.SaveChangesAsync();
        }
    }
}
