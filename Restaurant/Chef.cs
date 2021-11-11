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
        public bool Working { get; set; }
        public event EventHandler<Meal> FinishedMealEvent;
        public Chef(int id)
        {
            Id = id;
        }
        public async Task PrepareTheMeal(Meal meal)
        {
            Working = true;
            foreach (Step item in meal.StepsToMake)
            {
                Console.WriteLine($"Chef{Id + 1}:");
                await item.Proceed();
            }
            Working = false;
            FinishedMealEvent?.Invoke(this, meal);
            meal.Finished = true;
        }
    }
}
