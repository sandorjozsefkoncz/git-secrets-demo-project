using System;
using System.Configuration;

namespace GitSecretsDemoProject
{
    internal static class TemporalMagic
    {
        public static string KeyPhrase { get; set; } = ConfigurationManager.AppSettings.Get("AES_PassPhrase");
        public static string Salt = ConfigurationManager.AppSettings.Get("AES_Salt");

        internal static void EnsureKeysAreProvided()
        {
            if (KeyPhrase == "#{Octo_AES_password}" || Salt == "#{Octo_AES_Salt}")
                throw new ApplicationException("You have to provide the octopus variables to the project!");

            var decryptedTestCode = "";
            try
            {
                decryptedTestCode = Decrpyt(ConfigurationManager.AppSettings.Get("AES_Test_Crypted"));
            }
            catch { }

            if (!decryptedTestCode.Equals(ConfigurationManager.AppSettings.Get("AES_Test_Clear")))
                throw new ApplicationException("The given AES_PassPhrase is not valid for the test code!");
        }

        internal static string Encrypt(string text)
        {
            return EncryptionHelper.Encrypt(text, KeyPhrase, Salt);
        }

        internal static string Decrpyt(string text)
        {
            return EncryptionHelper.Decrypt(text, KeyPhrase, Salt);
        }
    }
}
