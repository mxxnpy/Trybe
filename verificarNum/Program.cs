using System;

class Program
{
    static void Main()
    {
        // Solicita ao usuário que digite um número
        Console.Write("Digite um número: ");
        double numero = Convert.ToDouble(Console.ReadLine());

        // Verifica se o número é positivo, negativo ou zero
        if (numero > 0)
        {
            Console.WriteLine("O número é positivo.");
        }
        else if (numero < 0)
        {
            Console.WriteLine("O número é negativo.");
        }
        else
        {
            Console.WriteLine("O número é zero.");
        }
    }
}
