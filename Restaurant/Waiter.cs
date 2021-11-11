using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Waiter
    {
        public int Id { get; set; }
        public bool Working { get; set; }
        public Waiter(int id)
        {
            Id = id;
            Working = false;
        }
        public async Task Deliver(Meal m)
        {
            Working = true;
            Console.WriteLine($"Waiter{Id} is delivering {m.Name} to the customer....");
            await Task.Delay(2000);
            Console.WriteLine("Meal delivered to customer");
            Working = false;
        }
        
    }
}
