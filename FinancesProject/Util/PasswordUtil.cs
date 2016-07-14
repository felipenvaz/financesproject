using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace FinancesProject.Util
{
    public static class PasswordUtil
    {
        public static string HashPassword(string password) {

            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);

            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(bytes);
            return Convert.ToBase64String(sha1data);
        }
    }
}