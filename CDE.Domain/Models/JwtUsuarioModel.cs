using System;
using System.Collections.Generic;
using System.Text;

namespace CDE.Domain.Models
{
    public class JwtUsuarioModel
    {
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioEmail { get; set; }

        public JwtUsuarioModel(int usuarioId, string usuarioNome, string usuarioEmail)
        {
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;
            UsuarioEmail = usuarioEmail;
        }
    }
}
