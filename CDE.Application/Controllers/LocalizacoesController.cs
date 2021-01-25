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
                _localizacaoRepository.Adicionar(novoLocal);

                return Created("", novoLocal);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar local ({ex})");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarLocalizacao(AtualizarLocalizacaoViewModel atualizarLocal)
        {
            try
            {
                _localizacaoRepository.Atualizar(atualizarLocal);

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
                var idNaoEncontrado = await _localizacaoRepository.Deletar(id);
                if (idNaoEncontrado)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao tentar remover local ({ex})");
            }
        }
    }
}
