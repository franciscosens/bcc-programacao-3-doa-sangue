using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Utils
    {
        public static string GetCrypt512(string texto)
        {
            StringBuilder sBuilder = new StringBuilder();
            SHA512 sha512 = SHA512.Create();
            byte[] data = sha512.ComputeHash(Encoding.UTF8.GetBytes(texto));
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.AppendFormat("{0:x2}", data[i]);
            }

            return sBuilder.ToString().ToUpper();
        }

        public static string GenerateToken(string login)
        {
            return GetCrypt512(login);
        }

    }
}
