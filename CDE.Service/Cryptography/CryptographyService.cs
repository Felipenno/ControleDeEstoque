using CDE.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Text;

namespace CDE.Service.Cryptography
{
    public class CryptographyService : ICryptographyService
    {
        private const string _salt = "Vwa4A/[FAfa170af-}&*#54ad$bgcxb@adw?A";

        public string CreateEncryption(string passWord)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
            password: passWord,
            salt: Encoding.UTF8.GetBytes(_salt),
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 10000,
            numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }
    }
}
