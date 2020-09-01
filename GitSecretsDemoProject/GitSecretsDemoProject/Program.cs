using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GitSecretsDemoProject
{
    public class Program
    {

        [STAThreadAttribute]
        static void Main(string[] args)
        {

            Console.WriteLine("Temporal magic V1.0");

            TemporalMagic.EnsureKeysAreProvided();

            ConsoleKeyInfo key;

            do
            {
                Console.WriteLine("Press a key to read your clipboard, encrypt it and put it back to the clipboard (Press ESC to exit)");
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                    break;

                try
                {
                    var password = Clipboard.GetText();
                    if (string.IsNullOrEmpty(password))
                    {
                        Console.WriteLine("No valid string found!");
                        continue;
                    }

                    Console.WriteLine("Clear: " + password);

                    var encrypted = TemporalMagic.Encrypt(password);

                    Console.WriteLine("Encrypted: " + encrypted);
                    Clipboard.SetText("SecretHelper.Reveal(\""+encrypted+"\")");

                    Console.WriteLine();
                    Console.WriteLine("Copied to clipboard");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong: " + e.Message);
                }
            }
            while (true);
        }
    }
}
