using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HurriyetciYerelSenAdmin.Managers
{
    public class Cryption
    {
        public static string Encrypt(string password)
        {
            const string EncryptionKey = "Hurriyet";
            var clearBytes = Encoding.Unicode.GetBytes(password);

            Aes encryptor = null;
            try
            {
                encryptor = Aes.Create();
                var pdb = new Rfc2898DeriveBytes(EncryptionKey,
                    new byte[]
                    {
                        0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64,
                        0x65, 0x76
                    });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, encryptor.CreateEncryptor(),
                    CryptoStreamMode.Write);
                cs.Write(clearBytes, 0, clearBytes.Length);
                cs.Close();
                password = Convert.ToBase64String(ms.ToArray());
            }
            finally
            {
                encryptor?.Dispose();
            }

            return password;
        }

        public static string Decrypt(string password)
        {
            const string EncryptionKey = "Hurriyet";
            password = password.Replace(" ", "+");
            var cipherBytes = Convert.FromBase64String(password);

            Aes encryptor = null;
            try
            {
                encryptor = Aes.Create();
                var pdb = new Rfc2898DeriveBytes(EncryptionKey,
                    new byte[]
                    {
                        0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64,
                        0x76, 0x65, 0x64, 0x65, 0x76
                    });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                var ms = new MemoryStream();
                var cs = new CryptoStream(ms, encryptor.CreateDecryptor(),
                    CryptoStreamMode.Write);
                cs.Write(cipherBytes, 0, cipherBytes.Length);
                cs.Close();
                password = Encoding.Unicode.GetString(ms.ToArray());
            }
            finally
            {
                encryptor?.Dispose();
            }

            return password;
        }
    }
}