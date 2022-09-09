using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace ACS.Helpers
{
    public static class Helpers
    {
        public static string HashWithSalt(this string password)
        {
            var salt = "CHYzqe4plTMekNC88U^^1Q++";
            byte[] saltBytes = Encoding.ASCII.GetBytes(salt);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 100000,
                numBytesRequested: 512 / 8));
            return hashed;
        }
    }
}
