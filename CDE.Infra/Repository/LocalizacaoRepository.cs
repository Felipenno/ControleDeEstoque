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

        public void Adicionar(CriarLocalizacaoViewModel novoLocal)
        {
            Localizacao localizacao = new Localizacao(
                novoLocal.Andar,
                novoLocal.Corredor,
                novoLocal.Prateleira,
                novoLocal.Vao,
                novoLocal.ProdutoId
                );

            _context.Localizacao.Add(localizacao);
            _context.SaveChanges();
        }

        public void Atualizar(AtualizarLocalizacaoViewModel atualizarLocal)
        {
            Localizacao localizacao = new Localizacao(
                    atualizarLocal.LocalizacaoId,
                    atualizarLocal.Andar,
                    atualizarLocal.Corredor,
                    atualizarLocal.Prateleira,
                    atualizarLocal.Vao,
                    atualizarLocal.ProdutoId
                    );

            _context.Localizacao.Update(localizacao);
            _context.SaveChanges();
        }

        public async Task<bool> Deletar(int id)
        {
            var localizacao = await EncontrarPorIdAsync(id);
            if (localizacao == null)
            {
                return true;
            }

            _context.Localizacao.Remove(localizacao);
            _context.SaveChanges();

            return false;
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
