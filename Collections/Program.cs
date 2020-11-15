using System;

namespace CollectionsArray
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wensday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            daysOfWeek[2] = "Wednesday";

            Console.WriteLine("which day do you want to display?");
            Console.Write("(Monday = 1 etc.) > ");
            int iDay = int.Parse(Console.ReadLine());

            string chosenDay = daysOfWeek[iDay-1];
            Console.WriteLine($"That day is {chosenDay}");

            foreach (var day in daysOfWeek)
            {
                Console.WriteLine(day);
            }

            
        }
    }
}
