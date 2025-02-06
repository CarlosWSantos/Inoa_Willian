using Inoa_Willian;
using System;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        var compra = 0.0;
        var venda = 0.0;
        var ativo = "PETR4";

        var email = new Email();
        email.GetMail("C:\\Git\\Will\\Inoa_Willian\\config.txt");

        var ativoBrasil = new AtivoBrasil();
        while(true)
        {
            var preco = ativoBrasil.GetPrice("PETR4");
            string tendecia = ativoBrasil.GetPriceHistorico();
            if (preco < compra)
            {
                email.SendMail($"Ativo {ativo} caiu!", "Compre agora." + tendecia);
            }
            else if (preco > venda)
            {
                email.SendMail($"Ativo {ativo} subiu!", "Venda agora." + tendecia);
            }

            Thread.Sleep(1000*60*30);
        }
    }
}