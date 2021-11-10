using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Chef
    {
        public int Id { get; set; }
        public Chef(int id)
        {
            Id = id;
        }
        public async Task PrepareTheMeal(Meal meal)
        {
            foreach (Step item in meal.StepsToMake)
            {
                Console.WriteLine($"Chef{Id}:");
                await item.Proceed();
            }
        }
    }
}
