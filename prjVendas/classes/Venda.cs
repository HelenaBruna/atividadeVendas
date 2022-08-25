using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjVendas
{
    public class Venda
    {
        private int qtde;

        public int Qtde { get => qtde; set => qtde = value; }

        private double valor;

        public double Valor { get => valor; set => valor = value; }

        public Venda() 
        {
            this.Valor = 10;
            this.Qtde = 10;
        }

        public Venda(int qtd, double valor)
        {
            this.Valor = valor;
            this.Qtde = qtd;
        }

        public double valorMedio() 
        {
            return valor / qtde;
        }

    }
}
