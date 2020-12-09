using System;
using Abstração.Classes;

namespace Abstração
{
    class Program
    {
        static void Main(string[] args)
        {
            int parcelas = 1;

            Console.Clear();

            Console.WriteLine("----------------------------");
            Console.Write("Digite o valor da compra: ");
            double valorTotal = double.Parse(Console.ReadLine());
            Console.WriteLine("Selecione a forma de pagamento desejada:");
            Console.WriteLine("[1] - Boleto");
            Console.WriteLine("[2] - Débito");
            Console.WriteLine("[3] - Crédito");
            string escolha = Console.ReadLine();
            Console.WriteLine("----------------------------");
            if (escolha == "1" || escolha == "3")
            {
                Console.WriteLine("Deseja parcelar? (S/N)");
                string resposta = Console.ReadLine().ToUpper();
                if (resposta == "S")
                {
                    Console.WriteLine("Deseja parcelar em quantas vezes?");
                    parcelas = int.Parse(Console.ReadLine());
                }
            }


            switch (escolha)
            {
                case "1":
                    Boleto boleto = new Boleto();

                    boleto.Valor = valorTotal;

                    boleto.Registrar("123qweasdrty");

                    boleto.Desconto();
                    boleto.Juros(parcelas);

                    Console.Write($"O boleto {boleto.CodigoDeBarras} no valor de {boleto.ValorFinal().ToString("C")}");
                    if (parcelas > 1)
                    {
                        var valorParcela = (boleto.ValorFinal() / parcelas).ToString("C");
                        Console.WriteLine($" em {parcelas} parcelas de {valorParcela} cada");
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                    break;
                case "2":
                    Debito debito = new Debito();

                    debito.Valor = valorTotal;

                    debito.Desconto();

                    if (debito.Saldo < debito.Desconto())
                    {
                        Console.WriteLine("Saldo insuficiente, cancelando transação");
                    }
                    else
                    {
                        Console.WriteLine($"A compra de {debito.Pagar()} foi concluida com sucesso");
                    }

                    break;
                case "3":
                    Credito credito = new Credito();

                    credito.Valor = valorTotal;

                    credito.Juros(parcelas);
                    credito.Desconto();

                    if (credito.Limite < credito.Pagar())
                    {
                        Console.WriteLine("Limite insuficiente, cancelando transação");
                    }
                    else
                    {
                        Console.Write($"A compra de {credito.Pagar()} foi concluida com sucesso");
                        if (parcelas > 1)
                        {
                            var valorParcela = (credito.Pagar() / parcelas).ToString("C");
                            Console.WriteLine($" em {parcelas} parcelas de {valorParcela} cada");
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Escolha inválida");
                    break;
            }

        }
    }
}
