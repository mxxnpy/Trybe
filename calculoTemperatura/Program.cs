using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite a temperatura em Celsius:");
        if (double.TryParse(Console.ReadLine(), out double celsius))
        {
            double fahrenheit = (celsius * 9 / 5) + 32;
            Console.WriteLine($"A temperatura em Fahrenheit é: {fahrenheit:F2}");
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número.");
        }
    }
}