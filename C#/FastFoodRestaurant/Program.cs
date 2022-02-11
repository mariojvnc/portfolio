using System;

namespace FastFoodRestaurant // MARKOVIC
{
    class Program
    {
        static void Main(string[] args)
        {
            // 11:30 – 14:15
            Console.Title = "Markovic - Fastfoodrestaurant DriveIn";
            Restaurant mcDonalds = new Restaurant();
            mcDonalds.Simulate(
                new DateTime(2020, 11, 27, 11, 30, 0), // 11:30
                new DateTime(2020, 11, 27, 14, 15, 0)  // 14:15 
                );
            Console.ReadKey();
        }
    }
}
