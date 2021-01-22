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
            var usuario = await _usuarioRepository.Logar(login.UsuarioSenha, login.UsuarioEmail);
            if(usuario == null)
            {
                return BadRequest("Erro ao tentar acessar");
            }

            return Ok(usuario.UsuarioNome);
        }

        [Route("registrar")]
        [HttpPost]
        public IActionResult RegistrarUsuario(RegistrarUsuarioViewModel registrar)
        {
            Usuario usuario = new Usuario(registrar.UsuarioNome, registrar.UsuarioCpf, registrar.UsuarioEmail, registrar.UsuarioSenha);

            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.SalvarAsync();

            return Created("", registrar);
        }



    }
}
