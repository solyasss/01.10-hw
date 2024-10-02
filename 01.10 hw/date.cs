using System;

namespace hw
{ 
    public class Date
    {
        private int day;
        private int month;
        private int year;

        public Date(int day, int month, int year)
        {
            if (correct_date(day, month, year))
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }
        }
        public Date() : this(1, 1, 2000) { }

        public void set_day(int day)
        {
            if (day >= 1 && day <= days_in_month(month, year))
                this.day = day;
        }

        public void set_month(int month)
        {
            if (month >= 1 && month <= 12)
                this.month = month;
        }
        public void set_year(int year)
        {
            this.year = year;
        }
        public int get_day()
        {
            return day;
        }
        public int get_month()
        {
            return month;
        }

        public int get_year()
        {
            return year;
        }
        private bool correct_date(int day, int month, int year)
        {
            return day >= 1 && day <= days_in_month(month, year) && month >= 1 && month <= 12;
        }

        private int days_in_month(int month, int year)
        {
            int[] all_days= { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (month == 2 && leap_year(year))
            return 29;
            return all_days[month - 1];
        }

        private bool leap_year(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        public int between_days(Date date)
        {
            int difference = refill_into() - date.refill_into();

            if (difference < 0)
            {
                return -difference;
            }
            else
            {
                return difference;
            }
        }

        private int refill_into()
        {
            int total = day;
            for (int y = 1; y < year; y++)
            {
                total += leap_year(y) ? 366 : 365;
            }
            for (int m = 1; m < month; m++)
            {
                total += days_in_month(m, year);
            }
            return total;
        }

        public void add(int days)
        {
            int total = refill_into() + days;
            year = 1;
            while (total > (leap_year(year) ? 366 : 365))
            {
                total -= leap_year(year) ? 366 : 365;
                year++;
            }
            month = 1;
            while (total > days_in_month(month, year))
            {
                total -= days_in_month(month, year);
                month++;
            }
            day = total;
        }

        public void print()
        {
            Console.WriteLine($"{day:D2}.{month:D2}.{year}");
        }
    }
}
