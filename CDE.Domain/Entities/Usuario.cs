namespace CDE.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioCpf { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioSenha { get; set; }

        public Usuario(int usuarioId, string usuarioNome, string usuarioCpf, string usuarioEmail, string usuarioSenha)
        {
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;
            UsuarioCpf = usuarioCpf;
            UsuarioEmail = usuarioEmail;
            UsuarioSenha = usuarioSenha;
        }

        protected Usuario() { }
    }
}
