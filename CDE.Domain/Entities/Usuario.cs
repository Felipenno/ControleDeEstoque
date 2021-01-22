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
            UsuarioSenha = usuarioSenha;
        }

        public Usuario(int usuarioId, string usuarioNome, string usuarioCpf, string usuarioEmail, string usuarioSenha) : this(usuarioNome, usuarioCpf, usuarioEmail, usuarioSenha)
        {
            UsuarioId = usuarioId;
        }

        protected Usuario() { }
    }
}
