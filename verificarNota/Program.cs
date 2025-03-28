using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the grade (from 0 to 10): ");
        double grade = Convert.ToDouble(Console.ReadLine());

        if (grade < 0 || grade > 10)
        {
            Console.WriteLine("Invalid grade");
        }
        else if (grade >= 9)
        {
            Console.WriteLine("Excellent!");
        }
        else if (grade >= 7)
        {
            Console.WriteLine("Good!");
        }
        else if (grade >= 5)
        {
            Console.WriteLine("Average.");
        }
        else
        {
            Console.WriteLine("Insufficient.");
        }
    }
}
