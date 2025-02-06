using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inoa_Willian
{
    internal class Validador
    {
        static Validador instance;
        public string ativo;
        public double venda;
        public double compra;
        public Validador() { }

        public bool ValidarArgumentos(string [] args) 
        {
            try
            {
                ativo = args[0];
                venda = double.Parse(args[1]);
                compra = double.Parse(args[2]);
                return true;
            }
            catch 
            {
                Console.WriteLine("Os argumentos não seguiram o formato \"ATIVO VENDA COMPRA\" ou os valores de compra e venda estão em um formato errado.");
                return false;
            }
        }


        public static Validador GetInstancia()
        {
            if (instance == null)
            {
                instance = new Validador();
            }

            return instance;
        }
    }
}
