using System;
using System.Collections.Generic;
using System.IO;

class Estacionamento
{
    static string arquivoBanco = "banco_dados.txt";
    static Dictionary<string, DateTime> veiculos = new Dictionary<string, DateTime>();
    const decimal precoPorHora = 5.00m;
    const int capacidadeMaxima = 20;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== MENU ESTACIONAMENTO ===");
            Console.WriteLine("1. Registrar Entrada");
            Console.WriteLine("2. Registrar Saída");
            Console.WriteLine("3. Sair");
            Console.WriteLine("4. Ver veículos estacionados");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    RegistrarEntrada();
                    break;
                case "2":
                    RegistrarSaida();
                    break;
                case "3":
                    return;
                case "4":
                    ListarVeiculosEstacionados();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }
    }

    static void RegistrarEntrada()
    {
        CarregarBanco();

        if (veiculos.Count >= capacidadeMaxima)
        {
            Console.WriteLine("Estacionamento cheio. Não é possível registrar nova entrada.");
            return;
        }

        Console.Write("Digite a placa do veículo: ");
        string placa = Console.ReadLine().ToUpper();

        if (veiculos.ContainsKey(placa))
        {
            Console.WriteLine("Veículo já está registrado no estacionamento.");
        }
        else
        {
            DateTime agora = DateTime.Now;
            veiculos[placa] = agora;
            File.AppendAllText(arquivoBanco, $"{placa},true,{agora}\n");
            Console.WriteLine($"Entrada registrada para {placa} às {agora}");
        }
    }

    static void RegistrarSaida()
    {
        Console.Write("Digite a placa do veículo: ");
        string placa = Console.ReadLine().ToUpper();
        CarregarBanco();

        if (veiculos.ContainsKey(placa))
        {
            DateTime entrada = veiculos[placa];
            DateTime saida = DateTime.Now;

            if (saida < entrada)    
            {
                Console.WriteLine("Erro: A data de saída não pode ser anterior à data de entrada.");
                return;
            }

            TimeSpan duracao = saida - entrada;
            decimal valorPagar = (decimal)Math.Ceiling(duracao.TotalHours) * precoPorHora;

            Console.WriteLine($"Veículo {placa} permaneceu por {duracao.Days} dias, {duracao.Hours} horas e {duracao.Minutes} minutos.");
            Console.WriteLine($"Valor a pagar: R$ {valorPagar:F2}");
            veiculos.Remove(placa);
            File.AppendAllText(arquivoBanco, $"{placa},false,{saida}\n");
        }
        else
        {
            Console.WriteLine("Veículo não encontrado no sistema.");
        }
    }

    static void ListarVeiculosEstacionados()
    {
        CarregarBanco();

        if (veiculos.Count == 0)
        {
            Console.WriteLine("Nenhum veículo está estacionado atualmente.");
        }
        else
        {
            Console.WriteLine("\n=== Veículos Estacionados ===");
            foreach (var item in veiculos)
            {
                Console.WriteLine($"Placa: {item.Key} | Entrada: {item.Value}");
            }
            Console.WriteLine($"Total de veículos: {veiculos.Count} / {capacidadeMaxima}");
        }
    }

    static void CarregarBanco()
    {
        veiculos.Clear();
        if (File.Exists(arquivoBanco))
        {
            string[] linhas = File.ReadAllLines(arquivoBanco);
            foreach (string linha in linhas)
            {
                string[] partes = linha.Split(',');
                if (partes.Length == 3 && partes[1] == "true")
                {
                    veiculos[partes[0]] = DateTime.Parse(partes[2]);
                }
                else if (partes.Length == 3 && partes[1] == "false" && veiculos.ContainsKey(partes[0]))
                {
                    veiculos.Remove(partes[0]);
                }
            }
        }
    }
}
