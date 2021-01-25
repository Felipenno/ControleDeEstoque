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
                _produtoRepository.Adicionar(novoProduto);

                return Created("", novoProduto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar novo produto ({ex})");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(AtualizarProdutoViewModel atualizarProduto)
        {
            try
            {
                _produtoRepository.Atualizar(atualizarProduto);

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
                var idNaoEncontrado = await _produtoRepository.Deletar(id);
                if (idNaoEncontrado)
                {
                    return NotFound();
                }

                await _produtoRepository.Deletar(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao tentar deletar produto ({ex})");
            }
        }
    }
}
