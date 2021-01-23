using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CDE.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LocalizacoesController : Controller
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;

        public LocalizacoesController(ILocalizacaoRepository localizacaoRepository)
        {
            _localizacaoRepository = localizacaoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var listaLocalizacoes = await _localizacaoRepository.ListarTodosAsync();

                return Ok(listaLocalizacoes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar localizacoes ({ex})");
            }
        }

        [HttpPost]
        public IActionResult CriarLocalizacao(CriarLocalizacaoViewModel novoLocal)
        {
            try
            {
                Localizacao localizacao = new Localizacao(
                novoLocal.Andar,
                novoLocal.Corredor,
                novoLocal.Prateleira,
                novoLocal.Vao,
                novoLocal.ProdutoId
                );

                _localizacaoRepository.Adicionar(localizacao);

                return Created("", novoLocal);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar local ({ex})");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarLocalizacao(int id, AtualizarLocalizacaoViewModel atualizarLocal)
        {
            try
            {
                if (id != atualizarLocal.LocalizacaoId)
                {
                    return BadRequest();
                }

                Localizacao localizacao = new Localizacao(
                    atualizarLocal.LocalizacaoId,
                    atualizarLocal.Andar,
                    atualizarLocal.Corredor,
                    atualizarLocal.Prateleira,
                    atualizarLocal.Vao,
                    atualizarLocal.ProdutoId
                    );

                _localizacaoRepository.Atualizar(localizacao);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar local ({ex})");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverLocalizacao(int id)
        {
            try
            {
                var localizacao = await _localizacaoRepository.EncontrarPorIdAsync(id);
                if (localizacao == null)
                {
                    return NotFound();
                }

                _localizacaoRepository.Deletar(localizacao);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao tentar remover local ({ex})");
            }
        }
    }
}
