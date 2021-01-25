﻿using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Models;
using CDE.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public void Adicionar(CriarProdutoViewModel novoProduto)
        {

            Produto produto = new Produto(
            novoProduto.ProdutoNome,
            novoProduto.ProdutoQuantidade,
            novoProduto.ProdutoAtivo,
            novoProduto.ProdutoGrupo,
            novoProduto.ProdutoUnidadeMedida
            );

            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Atualizar(AtualizarProdutoViewModel atualizarProduto)
        {
            Produto produto = new Produto(
                    atualizarProduto.ProdutoId,
                    atualizarProduto.ProdutoNome,
                    atualizarProduto.ProdutoQuantidade,
                    atualizarProduto.ProdutoAtivo,
                    atualizarProduto.ProdutoGrupo,
                    atualizarProduto.ProdutoUnidadeMedida
                    );

            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public async Task<bool> Deletar(int id)
        {
            var localizacao = await EncontrarPorIdAsync(id);
            if (localizacao == null)
            {
                return true;
            }

            _context.Produtos.Remove(localizacao);
            _context.SaveChanges();

            return false;
        }

        public async Task<Produto> EncontrarPorNomeAsync(string produtoNome)
        {
            return await _context.Produtos.Where(x => x.ProdutoNome == produtoNome).FirstOrDefaultAsync();
        }

        public async Task<Produto> EncontrarPorIdAsync(int id)
        {
            return await _context.Produtos.Where(x => x.ProdutoId == id).FirstOrDefaultAsync();
        }

        public async Task<List<ListarProdutosViewModel>> ListarTodosAsync()
        {
            List<ListarProdutosViewModel> listarProdutos = new List<ListarProdutosViewModel>();
            List<Produto> produtos = await _context.Produtos.Include(l => l.ProdutoLocalizacao).ToListAsync();
            foreach (Produto p in produtos)
            {
                listarProdutos.Add(new ListarProdutosViewModel(
                    p.ProdutoId,
                    p.ProdutoNome,
                    p.ProdutoQuantidade,
                    p.ProdutoAtivo,
                    p.ProdutoGrupo,
                    p.ProdutoUnidadeMedida,
                    p.ProdutoLocalizacao
                    ));
            }

            return listarProdutos;
        }

    }
}
