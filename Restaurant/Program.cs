using System;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            var restaurant = RestauratCreator.CreateRestaurant();
            Console.WriteLine($"Created restaurant. {restaurant.Chefs.Count} chefs, {restaurant.Waiters.Count} waiters,{restaurant.Clients.Count} clients...");
            Console.ReadLine();
        }
    }
}
