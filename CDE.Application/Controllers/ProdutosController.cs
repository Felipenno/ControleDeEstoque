using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CDE.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
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
            var listaProdutos = await _produtoRepository.ListarTodosAsync();

            return Ok(listaProdutos);
        }

        [HttpPost]
        public IActionResult CriarProduto(CriarProdutoViewModel novoProduto)
        {
            Produto produto = new Produto(
                novoProduto.ProdutoNome,
                novoProduto.ProdutoQuantidade,
                novoProduto.ProdutoAtivo,
                novoProduto.ProdutoGrupo,
                novoProduto.ProdutoUnidadeMedida,
                novoProduto.ProdutoLocalizacao
                );

            _produtoRepository.Adicionar(produto);
            _produtoRepository.SalvarAsync();

            return Created("", novoProduto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, AtualizarProdutoViewModel atualizarProduto)
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
                atualizarProduto.ProdutoUnidadeMedida,
                atualizarProduto.ProdutoLocalizacao
                );

            _produtoRepository.Atualizar(produto);
            _produtoRepository.SalvarAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverProduto(int id)
        {
            var produto = await _produtoRepository.EncontrarPorIdAsync(id);
            if(produto == null)
            {
                return BadRequest();
            }

            _produtoRepository.Deletar(produto);
            _produtoRepository.SalvarAsync();

            return Ok();
        }
    }
}
