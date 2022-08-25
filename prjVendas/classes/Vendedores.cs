using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjVendas.classes
{
    public class Vendedores
    {
        private Vendedor[] osVendedores;
        public Vendedor[] OsVendedores { get => osVendedores;  set => osVendedores = value; }
        
        private int max;
        public int Max { get => max; set => max = value; }
        
        private int qtde;
        public int Qtde { get => qtde; set => qtde = value; }

        public Vendedores(int max)
        {
            this.Max = max;
            this.Qtde = 0;
            osVendedores = new Vendedor[max];
        }

        public bool addVendedor(Vendedor v)
        {
            bool podeAdicionar = (this.qtde < this.max);

            if (podeAdicionar)
            {
                this.osVendedores[this.qtde] = v;
                this.qtde++;
            }

            return podeAdicionar;
        }

        public bool delVendedor(Vendedor v)
        {
            bool podeRemover;
            int i = 0;
            while (i < this.max && !this.osVendedores[i].Equals(v))
            {
                i++;
            }
            podeRemover = (i < this.max);
            if (podeRemover)
            {
                while (i < this.max - 1)
                {
                    this.osVendedores[i] = this.osVendedores[i + 1];
                    i++;
                }
                this.osVendedores[i] = new Vendedor(-1);
                this.qtde--;
            }
            return podeRemover;
        }

        public Vendedor searchVendedor(Vendedor v)
        {
            foreach (var vendedor in osVendedores)
            {
                if (v.Equals(vendedor))
                {
                    return vendedor;
                }
            }

            return null;
        }

        public List<Vendedor> searchVendedor()
        {

            List<Vendedor> vendedores = new List<Vendedor>();

            foreach (var vendedor in osVendedores)
            {
                vendedores.Add(vendedor);
            }

            return vendedores;
        }

        public double valorVendas(Vendedor v)
        {
            double valorTotal = 0;

            foreach (var vendedor in osVendedores)
            {
                if (vendedor != null)
                {
                    if (v.Equals(vendedor))
                    {

                        if (vendedor.AsVenda != null)
                        {
                            foreach (var venda in vendedor.AsVenda)
                            {

                                if (venda != null)
                                {
                                    valorTotal += venda.Valor;
                                }

                            }
                        }

                    }
                }
            }

            return valorTotal;
        }

        public double valorComissao(Vendedor v)
        {
            double valorTotalComissao = 0;

            double valorTotal = valorVendas(v);

            double valorPerc = 0;

            foreach (var vendedor in osVendedores)
            {
                if (vendedor != null)
                {
                    if (v.Equals(vendedor))
                    {
                        valorPerc = vendedor.PercComissao;
                        break;
                    }
                }
            }

            valorTotalComissao = valorTotal * (valorPerc / 100);

            return valorTotalComissao;
        }

        public double valorVendasMedias(Vendedor v)
        {
            double valorMedia = 0;

            var vendedor = searchVendedor(v);

            foreach (var venda in vendedor.AsVenda)
            {
                if (venda != null)
                {
                    valorMedia += venda.valorMedio();
                }
            }

            return valorMedia;
        }




    }
}
