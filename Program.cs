using Inoa_Willian;
using System;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        var email = new Email();
        email.GetMail("C:\\Git\\Will\\Inoa_Willian\\config.txt");

        var validador = Validador.GetInstancia();
        if (!validador.ValidarArgumentos(args))
        {
            return;
        }

        var ativoBrasil = new AtivoBrasil();
        while(true)
        {
            var preco = ativoBrasil.GetPrice();
            string tendecia = ativoBrasil.GetPriceHistorico();
            if (preco < validador.compra)
            {
                email.SendMail($"Ativo {validador.ativo} caiu!", $"A cotação do ativo {validador.ativo} está em {preco}. <br>Compre agora. " + tendecia);
            }
            else if (preco > validador.venda)
            {
                email.SendMail($"Ativo {validador.ativo} subiu!", $"A cotação do ativo {validador.ativo} está em {preco}. <br>Venda agora. " + tendecia);
            }

            Thread.Sleep(1000*60*30);
        }
    }
}