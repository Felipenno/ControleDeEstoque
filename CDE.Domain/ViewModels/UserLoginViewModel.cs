using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace CDE.Domain.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        [EmailAddress]
        [Range(6, 40)]
        public string UserEmail { get; set; }

        [Required]
        [Range(6, 40)]
        public string UserPassword { get; set; }

        public void EncryptPassword()
        {
            var md5 = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(UserPassword);
            byte[] hash = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            UserPassword = sb.ToString();
        }
    }
}
