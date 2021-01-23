using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Models;
using CDE.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            _context.SaveChanges();
        }

        public void Atualizar(Localizacao localizacao)
        {
            _context.Localizacao.Update(localizacao);
            _context.SaveChanges();
        }

        public void Deletar(Localizacao localizacao)
        {
            _context.Localizacao.Remove(localizacao);
            _context.SaveChanges();
        }

        public async Task<Localizacao> EncontrarPorIdAsync(int id)
        {
            return await _context.Localizacao.Where(x => x.LocalizacaoId == id).FirstOrDefaultAsync();
        }

        public async Task<List<ListarLocalizacoesViewModel>> ListarTodosAsync()
        {
            List<ListarLocalizacoesViewModel> listarLocal = new List<ListarLocalizacoesViewModel>();
            List<Localizacao> local = await _context.Localizacao.Include(p => p.Produto).ToListAsync();
            foreach (Localizacao l in local)
            {
                listarLocal.Add(new ListarLocalizacoesViewModel(
                    l.LocalizacaoId,
                    l.Andar,
                    l.Corredor,
                    l.Prateleira,
                    l.Vao,
                    l.Produto.ProdutoNome,
                    l.Produto.ProdutoQuantidade,
                    l.Produto.ProdutoAtivo,
                    l.Produto.ProdutoGrupo,
                    l.Produto.ProdutoUnidadeMedida
                    ));
            }

            return listarLocal;
        }

    }
}
