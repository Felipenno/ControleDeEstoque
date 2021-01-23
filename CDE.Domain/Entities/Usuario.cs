using System.Security.Cryptography;
using System.Text;

namespace CDE.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; private set; }
        public string UsuarioNome { get; private set; }
        public string UsuarioCpf { get; private set; }
        public string UsuarioEmail { get; private set; }
        public string UsuarioSenha { get; private set; }

        public Usuario(string usuarioNome, string usuarioCpf)
        {
            UsuarioNome = usuarioNome;
            UsuarioCpf = usuarioCpf;
        }

        public Usuario(string usuarioNome, string usuarioCpf, string usuarioEmail, string usuarioSenha) : this(usuarioNome, usuarioCpf)
        {

            UsuarioEmail = usuarioEmail;
            UsuarioSenha = Codificar(usuarioSenha);
        }

        public Usuario(int usuarioId, string usuarioNome, string usuarioCpf, string usuarioEmail, string usuarioSenha) : this(usuarioNome, usuarioCpf, usuarioEmail, usuarioSenha)
        {
            UsuarioId = usuarioId;
        }

        protected Usuario() { }

        public string Codificar(string texto)
        {
            var md5 = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(texto);
            byte[] hash = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
