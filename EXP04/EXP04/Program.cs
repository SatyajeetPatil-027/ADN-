using System;
using System.Collections.Generic;
using System.Linq;

namespace Exp04
{
    class Program
    {
        //Delegate for Calculator
        public delegate double Calculator(double a, double b);

        // Normal Methods (will later replace with lambda)
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;

        //  Multicast Delegate
        public delegate void Notify();

        static void Message1()
        {
            Console.WriteLine("Message 1: Operation Completed");
        }

        static void Message2()
        {
            Console.WriteLine("Message 2: Thank You!");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== EXPERIMENT 4 ===\n");

            //  Calculator using Delegate
            Calculator calc;

            calc = Add;
            Console.WriteLine("Addition: " + calc(10, 5));

            calc = Subtract;
            Console.WriteLine("Subtraction: " + calc(10, 5));

            //  Replace Methods with Lambda Expressions
            Calculator multiply = (a, b) => a * b;
            Calculator divide = (a, b) => a / b;

            Console.WriteLine("Multiplication (Lambda): " + multiply(10, 5));
            Console.WriteLine("Division (Lambda): " + divide(10, 5));

            Console.WriteLine("\n---------------------");

            //  Multicast Delegate Example
            Notify notify = Message1;
            notify += Message2;  // Multicast

            notify();

            Console.WriteLine("\n---------------------");

            //  Sort List using Lambda
            List<int> numbers = new List<int> { 5, 2, 8, 1, 9 };

            numbers.Sort((a, b) => a.CompareTo(b));

            Console.WriteLine("Sorted List:");
            foreach (var num in numbers)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine("\n---------------------");

            //  LINQ Query Example
            List<int> marks = new List<int> { 45, 80, 67, 30, 90, 55 };

            var passedStudents = from m in marks
                                 where m >= 50
                                 select m;

            Console.WriteLine("Students who Passed (LINQ Query):");
            foreach (var m in passedStudents)
            {
                Console.Write(m + " ");
            }

            Console.WriteLine("\n");

            // LINQ using Lambda Syntax
            var distinction = marks.Where(m => m >= 75);

            Console.WriteLine("Distinction (Lambda + LINQ):");
            foreach (var m in distinction)
            {
                Console.Write(m + " ");
            }

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
