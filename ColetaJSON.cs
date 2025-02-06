using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inoa_Willian
{
    //obj result
    internal class Resultado
    {
        //unico valor do result
        public List<HistoricoAtivos> results { get; set; }
    }

    //lista de items "historiclDataPrice"
    internal class HistoricoAtivos
    {
        public double regularMarketPrice { get; set; }
        public List<HistoricoPreco> historicalDataPrice { get; set; }
    }

    //cada valor de fechamento da lista de items do historico
    internal class HistoricoPreco
    {
        public double close { get; set;}
    }
}
