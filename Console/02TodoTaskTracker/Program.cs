using System;
using System.Runtime.CompilerServices;

namespace task_manager
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;

            while(isRunning)
            {
                Console.WriteLine("TASK MANAGER");
                Console.WriteLine("1. VIEW CALENDAR");
                Console.WriteLine("2. VIEW TASKS");
                Console.WriteLine("3. ADD TASK");
                Console.WriteLine("4. REMOVE TASK");
                Console.WriteLine("5. UPDATE TASK");
                Console.WriteLine("6. EXIT");
            }
        }
    }
}