using System;

namespace SRPExample
{
    // Class 1: Holds Student Data (Single Responsibility: Store Data)
    class Student
    {
        public string Name { get; set; }
        public int Marks { get; set; }
    }

    // Class 2: Responsible for Grade Calculation
    class GradeCalculator
    {
        public string CalculateGrade(int marks)
        {
            if (marks >= 75)
                return "Distinction";
            else if (marks >= 60)
                return "First Class";
            else if (marks >= 50)
                return "Second Class";
            else if (marks >= 35)
                return "Pass";
            else
                return "Fail";
        }
    }

    // Class 3: Responsible for Displaying Information
    class StudentPrinter
    {
        public void PrintDetails(Student student, string grade)
        {
            Console.WriteLine("\nStudent Details:");
            Console.WriteLine("Name: " + student.Name);
            Console.WriteLine("Marks: " + student.Marks);
            Console.WriteLine("Grade: " + grade);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Taking Input
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());

            // Creating Student Object
            Student student = new Student
            {
                Name = name,
                Marks = marks
            };

            // Calculating Grade
            GradeCalculator calculator = new GradeCalculator();
            string grade = calculator.CalculateGrade(student.Marks);

            // Printing Details
            StudentPrinter printer = new StudentPrinter();
            printer.PrintDetails(student, grade);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
