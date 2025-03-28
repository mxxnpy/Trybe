using System;

class Program
{
    static void Main()
    {
        int age = GetUserAge();
        string category = ClassifyAge(age);
        DisplayResult(category);
    }

    static int GetUserAge()
    {
        Console.Write("Please enter your age: ");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input) || !IsValidAge(input))
        {
            DisplayResult("Error: Invalid input! Please enter a valid age.");
            Environment.Exit(1);
        }

        return Convert.ToInt32(input);
    }

    static bool IsValidAge(string input)
    {
        foreach (char c in input)
        {
            if (!Char.IsDigit(c))
                return false;
        }
        return true;
    }

    static string ClassifyAge(int age)
    {
        if (age < 18)
        {
            return "You are a minor.";
        }
        else if (age >= 18 && age < 65)
        {
            return "You are an adult.";
        }
        else
        {
            return "You are a senior.";
        }
    }

    static void DisplayResult(string message)
    {
        Console.WriteLine(message);
    }
}
