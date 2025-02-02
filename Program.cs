using Inoa_Willian;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var email = new Email();
        email.GetMail("C:\\Git\\Will\\Inoa_Willian\\config.txt");
        //email.SendMail();
        var ativoBrasil = new AtivoBrasil();
        Console.Write(ativoBrasil.GetPrice("PETR4"));
    }
}