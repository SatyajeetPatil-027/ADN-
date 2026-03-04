using System;

namespace OOPExample
{
    // Class Definition
    class Student
    {
        // Private Data Members (Encapsulation)
        private string name;
        private int rollNo;
        private double marks;

        // Public Method to Set Data
        public void SetDetails(string studentName, int studentRollNo, double studentMarks)
        {
            name = studentName;
            rollNo = studentRollNo;
            marks = studentMarks;
        }

        // Public Method to Display Data
        public void DisplayDetails()
        {
            Console.WriteLine("\nStudent Details:");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Roll No: " + rollNo);
            Console.WriteLine("Marks: " + marks);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creating Object of Student class
            Student s1 = new Student();

            // Taking Input from User
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Roll Number: ");
            int roll = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Marks: ");
            double marks = Convert.ToDouble(Console.ReadLine());

            // Calling Method to Set Data
            s1.SetDetails(name, roll, marks);

            // Calling Method to Display Data
            s1.DisplayDetails();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
