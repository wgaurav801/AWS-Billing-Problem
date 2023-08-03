using System;

namespace BillingEngine.Models
{
    public class MonthYear
    {
        public int Month { get; }
        public int Year { get; }
        public MonthYear(int month, int year)
        {
            Month = month;
            Year = year;
        }


        public bool IsLesserThan(DateTime dateTime)
        {
            if (Year < dateTime.Year)
            {
                return true;
            }

            if (Year > dateTime.Year)
            {
                return false;
            }

            return Month < dateTime.Month;
        }
    }
}