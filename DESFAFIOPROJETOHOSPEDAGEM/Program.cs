using System;
using System.Collections.Generic;
using DESFAFIOPROJETOHOSPEDAGEM.Model;
class Program
{
    static void Main()
    {
        Reserva reserva = new Reserva();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n===== HOTEL =====");
            Console.WriteLine("1. Cadastrar Suíte");
            Console.WriteLine("2. Cadastrar Hóspedes");
            Console.WriteLine("3. Definir Dias Reservados");
            Console.WriteLine("4. Verificar Quantidade de Hóspedes");
            Console.WriteLine("5. Calcular Valor da Diária");
            Console.WriteLine("6. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Tipo da suíte: ");
                    string tipo = Console.ReadLine();

                    int capacidade;
                    while (true)
                    {
                        Console.Write("Capacidade: ");
                        if (int.TryParse(Console.ReadLine(), out capacidade) && capacidade > 0)
                            break;
                        Console.WriteLine("Digite um número válido para capacidade.");
                    }

                    decimal valor;
                    while (true)
                    {
                        Console.Write("Valor da diária: ");
                        if (decimal.TryParse(Console.ReadLine(), out valor) && valor > 0)
                            break;
                        Console.WriteLine("Digite um valor válido para a diária.");
                    }

                    Suite suite = new Suite(tipo, capacidade, valor);
                    reserva.CadastrarSuite(suite);
                    Console.WriteLine("Suíte cadastrada com sucesso!");
                    break;

                case "2":
                    if (reserva.Suite == null)
                    {
                        Console.WriteLine("Cadastre uma suíte antes de adicionar hóspedes.");
                        break;
                    }

                    List<Pessoa> hospedes = new List<Pessoa>();
                    int qtd;
                    while (true)
                    {
                        Console.Write($"Quantos hóspedes deseja cadastrar? (máx {reserva.Suite.Capacidade}): ");
                        if (int.TryParse(Console.ReadLine(), out qtd) && qtd > 0 && qtd <= reserva.Suite.Capacidade)
                            break;
                        Console.WriteLine("Número inválido. Tente novamente.");
                    }

                    for (int i = 0; i < qtd; i++)
                    {
                        Console.Write($"Nome do hóspede {i + 1}: ");
                        string nome = Console.ReadLine();
                        Console.Write($"Sobrenome do hóspede {i + 1}: ");
                        string sobrenome = Console.ReadLine();

                        hospedes.Add(new Pessoa(nome, sobrenome));
                    }

                    try
                    {
                        reserva.CadastrarHospedes(hospedes);
                        Console.WriteLine("Hóspedes cadastrados com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                    }
                    break;

                case "3":
                    int dias;
                    while (true)
                    {
                        Console.Write("Digite a quantidade de dias reservados: ");
                        if (int.TryParse(Console.ReadLine(), out dias) && dias > 0)
                        {
                            reserva.DiasReservados = dias;
                            Console.WriteLine("Dias reservados definidos com sucesso!");
                            break;
                        }
                        Console.WriteLine("Número inválido. Tente novamente.");
                    }
                    break;

                case "4":
                    Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeDeHospedes()}");
                    break;

                case "5":
                    try
                    {
                        Console.WriteLine($"Valor da diária: R$ {reserva.CalcularValorDaDiaria():F2}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                    }
                    break;

                case "6":
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }

        Console.WriteLine("Programa encerrado.");
    }
}
