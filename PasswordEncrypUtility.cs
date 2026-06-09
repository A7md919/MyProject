using System;
using System.Security.Cryptography;
using System.Text;
namespace PasswordManager
{
    public static class PasswordEncryptionUtility
    {
        private static readonly string orderedContent = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly string randomContent = "4VTQSLfh89UJXynktDd0E2KqWzeYAuZ5cpaxMjsmg3Nw7CblFi1rG6IOPRvBHo";
        public static string Encrypt(string password)
        {
            var sb = new StringBuilder();
            foreach(var ch in password)
            {
                var charIndex = orderedContent.IndexOf(ch);
                sb.Append(randomContent[charIndex]);
            }
            return sb.ToString();
        }
        public static string Decrypt(string encryptedPassword)
        {
            var sb = new StringBuilder();
            foreach(var ch in encryptedPassword)
            {
                var charIndex = randomContent.IndexOf(ch);
                sb.Append(orderedContent[charIndex]);
            }
            return sb.ToString();
        }
    }
}