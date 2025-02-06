using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Inoa_Willian
{
    internal class AtivoBrasil
    {
        //lista para armazenar o historico de preços
        private List<HistoricoPreco> precosHistorico = new List<HistoricoPreco>();

        //coleta dos dados do ativo dado o nome do ativo
        public async Task<string> GetAtivo(string ativo)
        {
            var HttpClient = new HttpClient();

            //conversão do Json em uma string
            var json = await HttpClient.GetAsync($"https://brapi.dev/api/quote/{ativo}?range=1mo&interval=1d&token=tZrXAMDLs59Vgs8Zo2qom3");
            return await json.Content.ReadAsStringAsync();
        }

        public double GetPrice(string ativo)
        {
            var json = GetAtivo(ativo).Result;

            //desserializando o Json em classes para melhor manipulação
            Resultado resultado = JsonSerializer.Deserialize<Resultado>(json);
            var historicoAtivo = resultado.results[0];
            precosHistorico = historicoAtivo.historicalDataPrice;
            return historicoAtivo.regularMarketPrice;
        }

        public string GetPriceHistorico(){
            double sum = 0;

            //verificando se o histórico possui algum valor
            if(precosHistorico.Count == 0)
            {
                throw new Exception();
            }

            //Dado a soma das diferenças do histórico de preços, retorna se o ativo tem apresentado uma tendência
            for (int i = 1; i < precosHistorico.Count; i++)
            {
                sum += precosHistorico[i - 1].close - precosHistorico[i].close;
            }
            if (sum > 0)
            {
                return "Alerta, o ativo tem apresentado uma <b>baixa</b> com base nos valores dos últimos 30 dias";
            }
            else if(sum == 0)
            {
                return "Alerta, o ativo tem apresentado uma <b>estabilidade</b> com base nos valores dos últimos 30 dias";
            }
            else
            {
                return "Alerta, o ativo tem apresentado uma <b>alta</b> com base nos valores dos últimos 30 dias";
            }
        }
    }
}
