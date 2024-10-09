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
            try
            {
                if (!correct_date(day, month, year))
                {
                    throw new ArgumentOutOfRangeException("Incorrect date");
                }

                this.day = day;
                this.month = month;
                this.year = year;
            }
            catch (ArgumentOutOfRangeException ex) when (day < 1 || day > days_in_month(month, year))
            {
                Console.WriteLine($"Error: {ex.Message} incorrect value of date ");
                throw;
            }
            catch (ArgumentOutOfRangeException ex) when (month < 1 || month > 12)
            {
                Console.WriteLine($"Error: {ex.Message} incorrect value of month");
                throw;
            }
        }

        public Date() : this(1, 1, 2000) { }
        public void set_day(int day)
        {
            try
            {
                if (day < 1 || day > days_in_month(month, year))
                {
                    throw new ArgumentOutOfRangeException("Incorrect day");
                }
                this.day = day;
            }
            catch (ArgumentOutOfRangeException ex) when (day < 1 || day > days_in_month(month, year))
            {
                Console.WriteLine($"Eror: {ex.Message} incorrect value of date");
                throw;
            }
        }

        public int get_day()
        {
            return day;
        }
        public void set_month(int month)
        {
            try
            {
                if (month < 1 || month > 12)
                {
                    throw new ArgumentOutOfRangeException("Incorrect month");
                }
                this.month = month;
            }
            catch (ArgumentOutOfRangeException ex) when (month < 1 || month > 12)
            {
                Console.WriteLine($"Error: {ex.Message} incorrect value of month");
                throw;
            }
        }

        public int get_month()
        {
            return month;
        }
        public void set_year(int year)
        {
            try
            {
                if (year < 1)
                {
                    throw new ArgumentOutOfRangeException("Incorrect year");
                }
                this.year = year;
            }
            catch (ArgumentOutOfRangeException ex) when (year < 1)
            {
                Console.WriteLine($"Error: {ex.Message}incorrect value of year");
                throw;
            }
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
            int[] all_days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (month == 2 && leap_year(year))
            {
                return 29;
            }
            return all_days[month - 1];
        }

        private bool leap_year(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        public void print()
        {
            Console.WriteLine($"{day:D2}.{month:D2}.{year}");
        }

        public void add(int days)
        {
            try
            {
                if (days < 0)
                {
                    throw new ArgumentOutOfRangeException( "value of days cannot be negative");
                }

                // контролирую переполнение при добавлении
                int total;
                try
                {
                    total = checked(refill_into() + days);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error with refilling ");
                    throw;
                }

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
            catch (ArgumentOutOfRangeException ex) when (days < 0)
            {
                Console.WriteLine($" {ex.Message} incorrect value of amount of days");
                throw;
            }
        }

        private int refill_into()
        {
            unchecked
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
        }

        // Overloaded binary operator '-'
        public static int operator -(Date date_1, Date date_2)
        {
            return date_1.refill_into() - date_2.refill_into();
        }

        // Overloaded operator '+'
        public static Date operator +(Date date, int days)
        {
            Date N_Date = new Date(date.day, date.month, date.year);
            N_Date.add(days);
            return N_Date;
        }

        // Operator '++'
        public static Date operator ++(Date date)
        {
            date.add(1);
            return date;
        }

        // Operator '--'
        public static Date operator --(Date date)
        {
            date.add(-1);
            return date;
        }

        // Operator '>'
        public static bool operator >(Date date_1, Date date_2)
        {
            return date_1.refill_into() > date_2.refill_into();
        }

        // Operator '<'
        public static bool operator <(Date date_1, Date date_2)
        {
            return date_1.refill_into() < date_2.refill_into();
        }

        // Operator '=='
        public static bool operator ==(Date date_1, Date date_2)
        {
            if ((object)date_1 == null && (object)date_2 == null)
            {
                return true;
            }
            if ((object)date_1 == null || (object)date_2 == null)
            {
                return false;
            }
            return date_1.day == date_2.day && date_1.month == date_2.month && date_1.year == date_2.year;
        }

        // Operator '!='                                                    
        public static bool operator !=(Date date_1, Date date_2)
        {
            return !(date_1 == date_2);
        }
    }
}