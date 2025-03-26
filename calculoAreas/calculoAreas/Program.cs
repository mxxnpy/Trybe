using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose the shape to calculate the area:");
        Console.WriteLine("1. Circle");
        Console.WriteLine("2. Rectangle");
        Console.WriteLine("3. Triangle");
        Console.WriteLine("4. Square");
        Console.WriteLine("5. Paper");
        Console.WriteLine("6. Monitor Screen");
        Console.WriteLine("Enter your choice (1-x): ");

        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return;
        }

        switch (choice)
        {
            case 1:
                CalculateCircleArea();
                break;
            case 2:
                CalculateRectangleArea();
                break;
            case 3:
                CalculateTriangleArea();
                break;
            case 4:
                CalculateSquareArea();
                break;
            case 5:
                CalculatePaperArea();
                break;
            case 6:
                CalculateScreenArea();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void CalculateCircleArea()
    {
        Console.Write("Enter the radius of the circle: ");
        if (double.TryParse(Console.ReadLine(), out double radius))
        {
            double area = Math.PI * radius * radius;
            Console.WriteLine($"The area of the circle is: {area}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static void CalculateRectangleArea()
    {
        Console.Write("Enter the width of the rectangle: ");
        if (double.TryParse(Console.ReadLine(), out double width))
        {
            Console.Write("Enter the height of the rectangle: ");
            if (double.TryParse(Console.ReadLine(), out double height))
            {
                double area = width * height;
                Console.WriteLine($"The area of the rectangle is: {area}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static void CalculateTriangleArea()
    {
        Console.Write("Enter the base of the triangle: ");
        if (double.TryParse(Console.ReadLine(), out double baseLength))
        {
            Console.Write("Enter the height of the triangle: ");
            if (double.TryParse(Console.ReadLine(), out double height))
            {
                double area = 0.5 * baseLength * height;
                Console.WriteLine($"The area of the triangle is: {area}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static void CalculateSquareArea()
    {
        Console.Write("Enter the side length of the square: ");
        if (double.TryParse(Console.ReadLine(), out double sideLength))
        {
            double area = sideLength * sideLength;
            Console.WriteLine($"The area of the square is: {area}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static void CalculatePaperArea()
    {
        Console.Write("Enter the length of the paper: ");
        if (double.TryParse(Console.ReadLine(), out double length))
        {
            Console.Write("Enter the width of the paper: ");
            if (double.TryParse(Console.ReadLine(), out double width))
            {
                double area = length * width;
                Console.WriteLine($"The area of the paper is: {area}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
    static void CalculateScreenArea()
    {
        Console.Write("Enter the width of the screen in pixels: ");
        if (int.TryParse(Console.ReadLine(), out int width))
        {
            Console.Write("Enter the height of the screen in pixels: ");
            if (int.TryParse(Console.ReadLine(), out int height))
            {
            int totalPixels = width * height;
            string quality;

            if (totalPixels >= 3840 * 2160)
            {
                quality = "4K or higher";
            }
            else if (totalPixels >= 2560 * 1440)
            {
                quality = "2K (QHD)";
            }
            else if (totalPixels >= 1920 * 1080)
            {
                quality = "Full HD (1080p)";
            }
            else if (totalPixels >= 1280 * 720)
            {
                quality = "HD (720p)";
            }
            else
            {
                quality = "Lower than HD";
            }

            Console.WriteLine($"The screen should support: {quality}");
            }
            else
            {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}