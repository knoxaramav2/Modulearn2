using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Modulearn2A.Utility
{
    public static class Security
    {
        public static bool VerifyPassword(string hash, string password, byte[] salt)
        {
            if (password == null) { return false; }

            byte[] saltBytes = salt;
            string compareHash = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: saltBytes,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 1000,
                    numBytesRequested: 16
                    )
                );

            return compareHash == hash;
        }

        public static string HashPassword(string password, out byte[] generateSalt)
        {
            if (password == null) { generateSalt = new byte[16];  return null; }

            var salt = new byte[16];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var ret = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 1000,
                    numBytesRequested: 16
                    )
                );

            generateSalt = salt;

            return ret;
        }
    }
}
