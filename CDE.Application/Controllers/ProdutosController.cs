using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CDE.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var listaProdutos = await _produtoRepository.ListarTodosAsync();

                return Ok(listaProdutos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar produtos ({ex})");
            }
        }

        [HttpPost]
        public IActionResult CriarProduto(CriarProdutoViewModel novoProduto)
        {
            try
            {
                Produto produto = new Produto(
                novoProduto.ProdutoNome,
                novoProduto.ProdutoQuantidade,
                novoProduto.ProdutoAtivo,
                novoProduto.ProdutoGrupo,
                novoProduto.ProdutoUnidadeMedida
                );

                _produtoRepository.Adicionar(produto);

                return Created("", novoProduto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar novo produto ({ex})");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, AtualizarProdutoViewModel atualizarProduto)
        {
            try
            {
                if (id != atualizarProduto.ProdutoId)
                {
                    return BadRequest();
                }

                Produto produto = new Produto(
                    atualizarProduto.ProdutoId,
                    atualizarProduto.ProdutoNome,
                    atualizarProduto.ProdutoQuantidade,
                    atualizarProduto.ProdutoAtivo,
                    atualizarProduto.ProdutoGrupo,
                    atualizarProduto.ProdutoUnidadeMedida
                    );

                _produtoRepository.Atualizar(produto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao tentar atualizar produto ({ex})");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverProduto(int id)
        {
            try
            {
                var produto = await _produtoRepository.EncontrarPorIdAsync(id);
                if (produto == null)
                {
                    return BadRequest();
                }

                _produtoRepository.Deletar(produto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao tentar deletar produto ({ex})");
            }
        }
    }
}
