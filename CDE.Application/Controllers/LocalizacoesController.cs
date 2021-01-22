using CDE.Domain.Entities;
using CDE.Domain.Interfaces.Repository;
using CDE.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var listaLocalizacoes = await _localizacaoRepository.ListarTodosAsync();

            return Ok(listaLocalizacoes);
        }

        [HttpPost]
        public IActionResult CriarLocalizacao(CriarLocalizacaoViewModel novoLocal)
        {
            Localizacao localizacao = new Localizacao(novoLocal.Andar, novoLocal.Corredor, novoLocal.Prateleira, novoLocal.Vao);
            _localizacaoRepository.Adicionar(localizacao);
            _localizacaoRepository.SalvarAsync();

            return Created("", novoLocal);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarLocalizacao(int id, AtualizarLocalizacaoViewModel atualizarLocal)
        {
            if (id != atualizarLocal.LocalizacaoId)
            {
                return BadRequest();
            }

            Localizacao localizacao = new Localizacao(atualizarLocal.LocalizacaoId, atualizarLocal.Andar, atualizarLocal.Corredor, atualizarLocal.Prateleira, atualizarLocal.Vao); ;

            _localizacaoRepository.Atualizar(localizacao);
            _localizacaoRepository.SalvarAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverLocalizacao(int id)
        {
            var localizacao = await _localizacaoRepository.EncontrarPorIdAsync(id);
            if(localizacao == null)
            {
                return NotFound();
            }

            _localizacaoRepository.Deletar(localizacao);
            _localizacaoRepository.SalvarAsync();

            return Ok();
        }
    }
}
