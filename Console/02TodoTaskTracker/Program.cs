using System;
using task_manager.controller;
using task_manager.service;
using task_manager.repository;

namespace task_manager
{
    public class Program
    {
        static void Main(string[] args)
        {
            CalendarService calendarService = new CalendarService();
            CalendarController calendarController = new CalendarController();

            ITaskRepository repository = new JsonRepository();
            TaskService taskService = new TaskService(repository);


            bool isRunning = true;

            while(isRunning)
            {
                Console.Clear(); //Clear the console for better readability
                Console.WriteLine("=========TASK MANAGER=========");
                Console.WriteLine("1. VIEW CALENDAR");
                Console.WriteLine("2. VIEW TASKS");
                Console.WriteLine("3. ADD TASK");
                Console.WriteLine("4. REMOVE TASK");
                Console.WriteLine("5. UPDATE TASK");
                Console.WriteLine("6. EXIT");
                Console.Write("==================");

                Console.Write("Enter your option: ");
                string input = Console.ReadLine() ?? "";

                switch (input)
                {
                    case "1":
                        // Display Calendar
                        DateTime now = DateTime.Now;
                        calendarController.DisplayMonth(now.Year, now.Month);
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadLine();
                        break;
                    case "2":
                        
                        Console.Clear();
                        taskService.PrintTasks();
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadLine();
                        // View Tasks
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("ADD NEW TASK");
                        
                        Console.Write("Enter Date (YYYY-MM-DD):[Leave empty for today] ");
                        string dateInput = Console.ReadLine() ?? "";
                        DateTime targetDate;

                        if(string.IsNullOrEmpty(dateInput))
                        {
                            targetDate = DateTime.Now;
                        }
                        else if(!DateTime.TryParse(dateInput, out targetDate))
                        {
                            Console.WriteLine("Invalid date format. Press any key to return to the main menu...");
                            targetDate = DateTime.Now;
                        }

                        Console.Write("Enter Task Name: ");
                        string taskName = Console.ReadLine() ?? "";

                        Console.Write("Enter Task Priority (1(highest) - 5(lowest)): ");
                        string priorityInput = Console.ReadLine() ?? "";
                        short priority = 5; // Default priority
                        short.TryParse(priorityInput, out priority);

                        taskService.AddTask(targetDate, taskName, priority);

                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadLine();
                        // Add Task
                        break;
                    case "4":
                        // Remove Task
                        break;
                    case "5":
                        // Update Task
                        break;
                    case "6":
                        isRunning = false; // Exit the application
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}