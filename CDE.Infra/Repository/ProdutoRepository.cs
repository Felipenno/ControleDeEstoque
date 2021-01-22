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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CDEContext _context;

        public ProdutoRepository(CDEContext context)
        {
            _context = context;
        }

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public void Deletar(Produto produto)
        {
            _context.Produtos.Remove(produto);
        }

        public async Task<Produto> EncontrarPorNomeAsync(string produtoNome)
        {
            return await _context.Produtos.Where(x => x.ProdutoNome == produtoNome).FirstOrDefaultAsync();
        }

        public async Task<Produto> EncontrarPorIdAsync(int id)
        {
            return await _context.Produtos.Where(x => x.ProdutoId == id).FirstOrDefaultAsync();
        }

        public async Task<Produto[]> ListarTodosAsync()
        {
            return await _context.Produtos.ToArrayAsync();
        }

        public void SalvarAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
