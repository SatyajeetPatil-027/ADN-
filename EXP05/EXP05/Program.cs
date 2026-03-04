using System;
using System.Threading;
using System.Threading.Tasks;

namespace EXP05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Synchronous Execution ===");
            SyncMethod();

            Console.WriteLine("\n=== Asynchronous Execution ===");
            AsyncMethod().Wait();   // Waiting because Main is not async

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Synchronous Method (uses Thread.Sleep)
        static void SyncMethod()
        {
            Console.WriteLine("Step 1 Started");
            Thread.Sleep(2000);   // Blocks thread for 2 seconds
            Console.WriteLine("Step 1 Completed");
        }

        //  Asynchronous Method (uses Task.Delay instead of Thread.Sleep)
        static async Task AsyncMethod()
        {
            Console.WriteLine("Step 2 Started");
            await Task.Delay(2000);  // Non-blocking delay
            Console.WriteLine("Step 2 Completed");

            //  Calling method that returns Task
            await AnotherTaskMethod();
        }

        //  Method Returning Task
        static async Task AnotherTaskMethod()
        {
            Console.WriteLine("Another Task Started");
            await Task.Delay(1000);
            Console.WriteLine("Another Task Completed");
        }
    }
}
