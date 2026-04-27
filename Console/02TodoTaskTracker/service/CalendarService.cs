using System;

namespace task_manager.service
{
    public class CalendarService
    {
        static readonly int[] daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public int GetDaysInMonth(int year, int month)
        {
            if(month == 2 && IsLeapYear(year))
            {
                return 29;
            }
            return daysInMonth[month-1];
        }
        public bool IsLeapYear(int year)
        {
            return (year%4 == 0 && year% 100 != 0 || year%400 == 0);
        }

        public int GetStartDayofWeek(int year, int month)
        {
            int totalDays = (year - 1)*365 + ((year - 1)/4) - ((year - 1)/100) + ((year - 1)/400);
            for(int i = 1; i<month;i++)
            {
                totalDays += GetDaysInMonth(year, i);
            }

            totalDays += 1; // Add 1 for the first day of the month

            return totalDays % 7; // Return the day of the week (0 = Sunday, 1 = Monday, ..., 6 = Saturday)
        }
    }
}