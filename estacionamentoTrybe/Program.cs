using System;
using System.Collections.Generic; // para usar o Dictionary para armazenar os dados
using System.IO; // para usar o File para ler e escrever no arquivo
using System.Globalization;

class Program
{
    const string arquivoDB = "estacionamento.txt"; // armazena: placa, entrada(bool) e datetime 
    const decimal precoHora = 5; 
    const int capacidade = 20;

    Dictionary<string, DateTime> estacionados;

    static void Main()
    {
        var program = new Program();
        program.Run();
    }

    Program()
    {
        estacionados = CarregarDados();
    }

    void Run()
    {
        string opcao; // armazena a escolha no menu

        do
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1 - Entrada");
            Console.WriteLine("2 - Saída");
            Console.WriteLine("3 - Listar"); // lista os veiculos estacionados e a quantidade de vagas
            Console.WriteLine("4 - Sair");
            Console.Write("Opção: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    if (estacionados.Count >= capacidade)
                    {
                        Console.WriteLine("Estacionamento lotado!");
                        break;
                    }

                    Console.Write("Placa: ");
                    string placa = Console.ReadLine().ToUpper(); // armazena a placa do veiculo

                    if (estacionados.ContainsKey(placa))
                    {
                        Console.WriteLine("Veículo já está estacionado!");
                    }
                    else
                    {
                        estacionados.Add(placa, DateTime.Now); // adiciona a placa e a data e hora da entrada
                        SalvarDados(estacionados); // salva os dados no txt
                        Console.WriteLine($"Entrada registrada: {placa}");
                    }
                    break;

                case "2":
                    Console.Write("Placa: ");
                    placa = Console.ReadLine()?.ToUpper() ?? string.Empty; // handle se for null

                    if (estacionados.TryGetValue(placa, out DateTime entrada))
                    {
                        var saida = DateTime.Now;
                        var horas = Math.Ceiling((saida - entrada).TotalHours);
                        var valor = Convert.ToDecimal(horas) * precoHora; // converte double para decimal

                        Console.WriteLine($"Tempo: {horas} horas");
                        Console.WriteLine($"Valor: R$ {valor:F2}");
                        estacionados.Remove(placa);
                        SalvarDados(estacionados);
                    }
                    else
                    {
                        Console.WriteLine("Veículo não encontrado!");
                    }
                    break;

                case "3":
                    Console.WriteLine("\nVeículos estacionados:");
                    foreach (var v in estacionados)
                    {
                        Console.WriteLine($"{v.Key} - {v.Value}");
                    }
                    Console.WriteLine($"Total: {estacionados.Count}/{capacidade}");
                    break;
            }

        } while (opcao != "4");
    }

    Dictionary<string, DateTime> CarregarDados()
    {
        var dados = new Dictionary<string, DateTime>();
        
        if (File.Exists(arquivoDB))
        {
            foreach (var linha in File.ReadAllLines(arquivoDB))
            {
                var partes = linha.Split(';');
                if (partes.Length == 2 && DateTime.TryParseExact(partes[1], "dd/MM/yyyy HH:mm:ss",
                    null, // usa null para o parâmetro IFormatProvider
                    DateTimeStyles.None, out DateTime data))
                {
                    dados[partes[0]] = data;
                }
            }
        }
        return dados;
    }

    void SalvarDados(Dictionary<string, DateTime> dados)
    {
        var linhas = new List<string>();
        foreach (var item in dados)
        {
            linhas.Add($"{item.Key};{item.Value.ToString("dd/MM/yyyy HH:mm:ss")}");
        }
        File.WriteAllLines(arquivoDB, linhas);
    }
}