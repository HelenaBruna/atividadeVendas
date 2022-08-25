using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjVendas.classes
{
    public class Vendedor
    {
        private int id;

        public int Id { get => id; set => id = value; }

        private string nome;

        public string Nome { get => nome; set => nome = value; }

        private double percComissao;

        public double PercComissao { get => percComissao; set => percComissao = value; }
        
        private Venda[] asVendas;

        public Venda[] AsVenda { get => asVendas; set => asVendas = value; }

        public Vendedor(int id, string nome, double comissao)
        {
            Id = id;
            Nome = nome;
            PercComissao = comissao;
            AsVenda = new Venda[31];
        }

        public Vendedor(int id)
        {
            Id = id;
            Nome = "";
            PercComissao = 0;
            AsVenda = new Venda[10];
        }
        
        public void registrarVenda(int dia, Venda venda)
        {
            AsVenda[dia] = venda;
        }

        //public double valorVendas()
        //{
        //    return 
        //}

        //public double valorComissao()
        //{
        //    return
        //}

        public override bool Equals(object obj)
        {
            return this.id.Equals(((Vendedor)obj).id);
        }


    }
}
