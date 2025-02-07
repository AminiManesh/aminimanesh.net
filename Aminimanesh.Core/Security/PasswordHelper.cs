using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aminimanesh.Core.Security
{
    public class PasswordHelper
    {
        public static string HashPasswordBcrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Validate password against hash
        public static bool VerifyPasswordBcrypt(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
