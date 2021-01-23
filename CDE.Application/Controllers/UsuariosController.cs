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
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Logar(LoginUsuarioViewModel login)
        {
            try
            {
                var usuario = await _usuarioRepository.Logar(login.UsuarioEmail, login.GetSenha());
                if (usuario == null)
                {
                    return BadRequest("Dados incorretos");
                }

                return Ok(usuario.UsuarioNome);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao tentar acessar ({ex})");
            }
        }

        [Route("registrar")]
        [HttpPost]
        public IActionResult RegistrarUsuario(RegistrarUsuarioViewModel registrar)
        {
            try
            {
                Usuario usuario = new Usuario(registrar.UsuarioNome, registrar.UsuarioCpf, registrar.UsuarioEmail, registrar.UsuarioSenha);

                _usuarioRepository.Adicionar(usuario);

                return Created("", registrar);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao registrar usuario ({ex})");
            }
        }

    }
}
