using System;

namespace ArithmeticOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Title
            Console.WriteLine("=== Basic Arithmetic Operations in C# ===\n");

            // Input from user
            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            // Perform arithmetic operations
            double sum = num1 + num2;
            double difference = num1 - num2;
            double product = num1 * num2;
            double quotient = (num2 != 0) ? num1 / num2 : 0;

            // Display results
            Console.WriteLine("\nResults:");
            Console.WriteLine($"Addition: {num1} + {num2} = {sum}");
            Console.WriteLine($"Subtraction: {num1} - {num2} = {difference}");
            Console.WriteLine($"Multiplication: {num1} * {num2} = {product}");

            if (num2 != 0)
                Console.WriteLine($"Division: {num1} / {num2} = {quotient}");
            else
                Console.WriteLine("Division: Cannot divide by zero");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
