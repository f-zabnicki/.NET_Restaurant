using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Menu
    {
        public List<Meal> Meals { get; set; }
        public Menu()
        {
            Meals = CreateBasicMenu();
        }
        private List<Meal> CreateBasicMenu()
        {
            return new List<Meal>() { new Meal("Egg with bacon", new List<Step>() { new Step("Boil the eggs", 3000), new Step("Fry the becon", 5000) }),
                                      new Meal("Sandwich", new List<Step>() { new Step("Prepare bread", 2000), new Step("Chop the vegetables", 6000), new Step("Fold the sandwich", 1500) }),
                                      new Meal("Oragne juice", new List<Step>() { new Step("Squeze oranges", 2500), new Step("Pour the juice", 1000) }) };
            
        }
        public void ShowMenu()
        {
            for (int i = 0; i < Meals.Count; i++)
            {
                Console.WriteLine($"{i+1}. {Meals[i].Name}, preparation time {Meals[i].TimeToMake}");
            }
        }
    }
}
