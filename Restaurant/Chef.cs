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
        public void PrepareTheMeal(Meal meal)
        {
            foreach (var item in meal.StepsToMake)
            {
                Console.WriteLine($"Chef is work on: {item.Name}");
                Task.Delay(item.TimeOfStep);
            }
        }
    }
}
