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
                Console.WriteLine("\nBasic data");
                second_date.print();

                second_date.set_day(10);
                second_date.set_month(12);
                second_date.set_year(2024);
                Console.WriteLine("\nNew data:");
                second_date.print();

                int between= date_first.between_days(second_date);
                Console.WriteLine($"\nAmount of days between dates");

                int add_days=10;
                Console.WriteLine($"\nAdd {add_days} days to first date");
                date_first.add(add_days);
                date_first.print();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Incorrect data");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:");
            }
        }
    }
}
