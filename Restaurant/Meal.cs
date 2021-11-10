using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Meal
    {
        public string Name { get; set; }
        public int TimeToMake { get; set; }
        public List<Step> StepsToMake { get; set; }
        public Meal(string name, List<Step> steps)
        {
            Name = name;
            StepsToMake = steps;
            TimeToMake = CalculateTimeToMakeMeal(steps);
        }

        private int CalculateTimeToMakeMeal(List<Step> steps)
        {
            int time = 0;
            foreach (Step step in steps)
                time = +step.TimeOfStep;
            return time;
        }
    }
}
