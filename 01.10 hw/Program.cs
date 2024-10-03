using System;

namespace hw
{
    class Client
    {
        static void Main(string[] arr)
        {
            try
            {
                Date date_first = new Date(01, 01, 2000);
                Console.WriteLine("First date:");
                date_first.print();

                Date second_date = new Date();
                Console.WriteLine("\nBasic date:");
                second_date.print();

                second_date.set_day(10);
                second_date.set_month(12);
                second_date.set_year(2024);
                Console.WriteLine("\nNew date:");
                second_date.print();

                // Using the overloaded - operator 
                int between = second_date - date_first;
                Console.WriteLine($"\nNumber of days between dates: {between}");

                // Using the overloaded + operator 
                int add_days = 10;
                Console.WriteLine($"\nAdding {add_days} days to the first date");
                Date new_date = date_first + add_days;
                new_date.print();

                // Using the overloaded ++ operator 
                Console.WriteLine("\nIncrementing the first date by one day");
                ++date_first;
                date_first.print();

                // Using the overloaded -- operator 
                Console.WriteLine("\nDecrementing the second date by one day");
                --second_date;
                second_date.print();

                // Comparing dates using overloaded > and < operators
                Console.WriteLine("\nComparing dates:");
                if (date_first > second_date)
                {
                    Console.WriteLine("First date is later");
                }
                else if (date_first < second_date)
                {
                    Console.WriteLine("First date is earlier");
                }
                else
                {
                    Console.WriteLine("Both dates are the same.");
                }

                // Checking if dates are equal using overloaded == and != operators
                Console.WriteLine("\nChecking if the dates are equal:");
                if (date_first == second_date)
                {
                    Console.WriteLine("Dates are equal.");
                }
                else
                {
                    Console.WriteLine("Dates are not equal.");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Incorrect data.");
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }
    }
}
