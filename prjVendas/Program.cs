using prjVendas.classes;
using System;

namespace prjVendas
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlador = -1;
            int opcao = 0;
            int contVendedor = 0;
            int idVendedor = 0;

            Vendedores vendedores = new Vendedores(10);

            while (controlador != 0)
            {
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar vendedor");
                Console.WriteLine("2. Consultar vendedor");
                Console.WriteLine("3. Excluir vendedor");
                Console.WriteLine("4. Registrar venda");
                Console.WriteLine("5. Listar vendedor");

                Console.WriteLine("Digite sua opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        controlador = 0;
                        break;
                    case 1:

                        if (contVendedor < 10)
                        {
                            Console.WriteLine("Digite o nome do vendedor: ");
                            string nome = Console.ReadLine();

                            Console.WriteLine("Digite a comissao: ");
                            double comissao = double.Parse(Console.ReadLine());

                            vendedores.addVendedor(new Vendedor(contVendedor, nome, comissao));

                            contVendedor++;
                        }
                        else
                        {
                            Console.WriteLine("Limite de cadastro de vendedores!");
                        }

                        break;
                    case 2:
                        Console.WriteLine("Digite o ID do vendedor: ");
                        idVendedor = int.Parse(Console.ReadLine());

                        var vendedorSearch = vendedores.searchVendedor(new Vendedor(idVendedor));

                        Console.WriteLine($"ID:{vendedorSearch.Id}");
                        Console.WriteLine($"Nome:{vendedorSearch.Nome}");
                        Console.WriteLine($"Comissao:{vendedorSearch.PercComissao}");

                        Console.WriteLine($"Valor total vendas: {vendedores.valorVendas(new Vendedor(idVendedor))}");

                        Console.WriteLine($"Valor total da comissao: {vendedores.valorComissao(new Vendedor(idVendedor))}");
                        Console.WriteLine($"Valor media: {vendedores.valorVendasMedias(new Vendedor(idVendedor))}");

                        break;
                    case 3:
                        Console.WriteLine("Digite o ID do vendedor: ");
                        idVendedor = int.Parse(Console.ReadLine());

                        vendedores.delVendedor(new Vendedor(idVendedor));
                        contVendedor--;
                        break;
                    case 4:
                        Console.WriteLine("Digite o ID do vendedor: ");
                        idVendedor = int.Parse(Console.ReadLine());

                        var vendedor = vendedores.searchVendedor(new Vendedor(idVendedor));

                        int diaVenda = 0;
                        double valorVenda = 0;
                        int qtdVenda = 0;

                        Console.WriteLine("Digite o dia da venda: ");
                        diaVenda = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite valor da venda: ");
                        valorVenda = double.Parse(Console.ReadLine());
                        Console.WriteLine("Digite a qtd da venda:");
                        qtdVenda = int.Parse(Console.ReadLine());

                        vendedor.registrarVenda(diaVenda, new Venda(qtdVenda, valorVenda));

                        break;
                    case 5:

                        var vend = vendedores.searchVendedor();

                        foreach (var info in vend)
                        {
                            if (info != null)
                            {
                                Console.WriteLine($"ID: {info.Id}");
                                Console.WriteLine($"NOME: {info.Nome}");
                                Console.WriteLine($"Valor total vendas: {vendedores.valorVendas(new Vendedor(info.Id))}");
                                Console.WriteLine($"Valor total da comissao: {vendedores.valorComissao(new Vendedor(info.Id))}");
                            }
                        }

                        break;
                    default:
                        break;
                }

            }
        }
    }
}
