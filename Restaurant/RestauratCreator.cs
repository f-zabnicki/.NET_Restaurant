using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    static class RestauratCreator
    {
        public static Restaurant CreateRestaurant()
        {
            Console.WriteLine("Set number of clients:");
            var clients = Console.ReadLine();
            Console.WriteLine("Set number of chefs:");
            var chefs = Console.ReadLine();
            Console.WriteLine("Set number of waiters:");
            var waiters = Console.ReadLine();
            try
            {
                var _clients = int.Parse(clients);
                var _chefs = int.Parse(chefs);
                var _waiters = int.Parse(waiters);
                return new Restaurant(_clients, _chefs, _waiters);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}
