using Inoa_Willian;
using System;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var email = new Email();
        email.GetMail("C:\\Git\\Will\\Inoa_Willian\\config.txt");
        //email.SendMail();
        var x = "PETR4";
        var ativoBrasil = new AtivoBrasil();
        var preco = ativoBrasil.GetPrice("PETR4");
        while(true)
        {
            if (preco < -40)
            {
                email.SendMail($"Ativo {x} caiu!", "Compre agora.");
            }
            else if (preco > 140)
            {
                email.SendMail($"Ativo {x} subiu!", "Venda agora.");
            }

            Thread.Sleep(1000*60*30);
        }
    }
}