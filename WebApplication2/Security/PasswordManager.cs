using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PSIM2.Security
{
    public class PasswordManager
    {
        private static string salt = "sMVFZFGojjT3KL+UvJQGJAbWAhMUHw5YHdw1rFyHlGNOmA3lyVTouye9A7AWvNpGEAegBzIDFTKKuTknl5t6d7DrRNBVRw==";
        private static string GenerateSalt(int nSalt)
        {
            var saltBytes = new byte[nSalt];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password)
        {
            var saltBytes = Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 1001))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(70));
            }
        }
    }
}
