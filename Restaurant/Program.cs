using System;
using System.Threading.Tasks;

namespace Restaurant
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var restaurant = RestauratCreator.CreateRestaurant();
            restaurant.Menu.ShowMenu();
            await restaurant.PlaceOrders();
        }
    }
}
