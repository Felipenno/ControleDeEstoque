using System.Security.Cryptography;
using System.Text;

namespace CDE.Domain.Models
{
    public class LoginUsuarioViewModel
    {
        public string UsuarioEmail { get; set; }
        public string UsuarioSenha { private get; set; }

        public string GetSenha()
        {
            var md5 = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(UsuarioSenha);
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
