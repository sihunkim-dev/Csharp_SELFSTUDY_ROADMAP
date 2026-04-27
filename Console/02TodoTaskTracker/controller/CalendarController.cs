using System;
using task_manager.service;
//Display the calendar which will show the whole calendar of the current month and the highlighted datee will be the current date. 

namespace task_manager.controller
{
    public class CalendarController
    {
        private readonly CalendarService _calendarService;

        public CalendarController()
        {
            this._calendarService = new CalendarService();
        }
        

        public void DisplayMonth(int year, int month)
        {
            Console.WriteLine($"\n[{year} - {month}]");
            Console.WriteLine("SUN\tMON\tTUE\tWED\tTHU\tFRI\tSAT");

            int startDay = _calendarService.GetStartDayofWeek(year, month);
            int daysInMonth = _calendarService.GetDaysInMonth(year, month);

            for (int i = 0; i<startDay; i++)
            {
                Console.Write("\t");
            }

            DateTime today = DateTime.Today;

            for(int day = 1; day <= daysInMonth; day++)
            {
                if(year == today.Year && month == today.Month && day == today.Day)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.Write($"{day}");
                    Console.ResetColor();
                    
                    Console.Write("\t");

                }
                else
                {
                    Console.Write($"{day}\t");
                }
                

                if((startDay + day) % 7 == 0)
                {
                    Console.WriteLine();
                }
            
            }

            Console.WriteLine();
        }
    }
}