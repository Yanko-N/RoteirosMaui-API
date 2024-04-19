using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace RoteirosMaui.Classes
{
    public static class EncripterWrapper
    {

        public static string HashPassword(string textPlain)
        {

            return BC.HashPassword(textPlain);
        }

        public static bool CheckHashAndPassword(string plainTextPassword, string hashedPassword)
        {
            return BC.Verify(plainTextPassword, hashedPassword);
        }

    }
}
