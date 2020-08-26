using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

public static class EncryptionHelper
{
    public static string Encrypt(string clearText, string passPhrase, string salt)
    {
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        byte[] saltBytes = Encoding.Unicode.GetBytes(salt);

        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(passPhrase, saltBytes);
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                var encrypted = Convert.ToBase64String(ms.ToArray());
                return encrypted;
            }
        }
    }

    public static string Decrypt(string cipherText, string encryptionKey, string salt)
    {
        byte[] cipherBytes = Convert.FromBase64String(cipherText.Replace(" ", "+"));
        byte[] saltBytes = Encoding.Unicode.GetBytes(salt);

        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, saltBytes);
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
}