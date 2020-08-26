using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitSecretsDemoProject
{
    public class Program
    {

        static void Main(string[] args)
        {
            TemporalMagic.EnsureKeysAreProvided();

            var secret = "SomeSecretsForTesting";

            var encrypted = TemporalMagic.Encrypt(secret);

            var decripted = TemporalMagic.Decrpyt(encrypted);

            Console.WriteLine("Original " + secret);
            Console.WriteLine("Encrypted " + encrypted);
            Console.WriteLine("Decrypted " + decripted);

            Console.WriteLine();
            Console.WriteLine(ThisIsMyStaticSecretBox.MyDatabasePassword);

            Console.ReadKey();
        }
    }
}
