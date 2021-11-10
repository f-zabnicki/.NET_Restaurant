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
            return new List<Meal>() { new Meal("Egg with bacon", new List<Step>() { new Step("Boil the eggs", 300), new Step("Fry the becon", 500) }),
                                      new Meal("Sandwich", new List<Step>() { new Step("Prepare bread", 200), new Step("Chop the vegetables", 600), new Step("Fold the sandwich", 150) }),
                                      new Meal("Oragne juice", new List<Step>() { new Step("Squeze oranges", 250), new Step("Pour the juice", 100) }) };
            
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
