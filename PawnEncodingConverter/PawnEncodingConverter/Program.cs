using System;
using System.IO;
using System.Text;

namespace PawnEncodingConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            ConfigReader config = new ConfigReader("encoding.cfg");

            string fileIn = config.Read("FileIn");
            string fileOut = config.Read("FileOut");

            Console.WriteLine($"Input file (UTF-8) >>> {fileIn}");
            Console.WriteLine($"Output file (Windows 1251) >>> {fileOut}");

            string fileInText = File.ReadAllText(fileIn, Encoding.UTF8);
            File.WriteAllText(fileOut, fileInText, Encoding.GetEncoding(1251));
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            File.WriteAllText("exept_pawn_conv.txt", e.ExceptionObject.ToString());
        }
    }
}
