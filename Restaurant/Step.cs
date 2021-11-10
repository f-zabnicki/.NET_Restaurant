using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Step
    {
        public string Name { get; set; }
        public int TimeOfStep { get; set; }
        public Step(string name, int timeUnit)
        {
            Name = name;
            TimeOfStep = timeUnit;
        }
        public async Task Proceed()
        {
            Console.WriteLine($"{Name}...");
            await Task.Delay(TimeOfStep);
        }
    }
}
