using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inoa_Willian
{
    internal class AtivoBrasil
    {
        public async Task<string> GetAtivo(string ativo)
        {
            var HttpClient = new HttpClient();
            var json = await HttpClient.GetAsync($"https://brapi.dev/api/quote/{ativo}?range=1d&interval=1d&token=tZrXAMDLs59Vgs8Zo2qom3");

            return await json.Content.ReadAsStringAsync();
        }

        public double GetPrice(string ativo)
        {
            var json = GetAtivo(ativo).Result;
            var index = json.IndexOf("regularMarketPrice");
            var preco = json.Substring(index + 20, 5);
            return Double.Parse(preco, CultureInfo.InvariantCulture);
        }
    }
}
