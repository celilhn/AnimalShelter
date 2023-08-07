using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;
using Application.Models;
using Application.Logging;
using System.Net.Mail;
using System.Net;
using System;

namespace Application.Utilities
{
    public static class AppUtilities
    {
        private static IConfiguration _configuration;  
   
        public static void AppUtilitiesConfigure(IConfiguration configuration)
        {
            _configuration = configuration;          
        }

        public static string GetConfigurationValue(string key)
        {
            return _configuration.GetSection(key).Value;
        }

        public static string EncryptSHA256(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool ValidatePassword(string password)
        {
            int digits = 0;
            int uppers = 0;
            int lowers = 0;
            int symbols = 0;
            foreach (var ch in password)
            {
                if (char.IsDigit(ch)) digits++;
                if (char.IsUpper(ch)) uppers++;
                if (char.IsLower(ch)) lowers++;
                if (!char.IsDigit(ch) && !char.IsUpper(ch) && !char.IsLower(ch))
                    symbols++;
            }
            if (password.Length < 8 || digits == 0 || uppers == 0 || lowers == 0 || symbols == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
