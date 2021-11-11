using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Restaurant
    {
        public bool IsOpen { get; set; }
        public List<Client> Clients { get; set; }
        public List<Chef> Chefs { get; set; }
        public List<Waiter> Waiters { get; set; }
        public Menu Menu { get; set; }
        public Queue<Meal> finished = new Queue<Meal> { };
        public Restaurant(int clients, int chefs, int waiters)
        {
            Clients = CreateListOfClients(clients);
            Chefs = CreateListOfChefs(chefs);
            Waiters = CreateListOfWaiters(waiters);
            Menu = new Menu();
            IsOpen = true;
        }
        private List<Client> CreateListOfClients(int quant)
        {
            var list = new List<Client>() { };
            for (int i = 0; i < quant; i++)
            {
                list.Add(new Client(i));
            }
            return list;
        }
        private List<Chef> CreateListOfChefs(int quant)
        {
            var list = new List<Chef>() { };
            for (int i = 0; i < quant; i++)
            {
                list.Add(new Chef(i));
            }
            return list;
        }
        private List<Waiter> CreateListOfWaiters(int quant)
        {
            var list = new List<Waiter>() { };
            for (int i = 0; i < quant; i++)
            {
                list.Add(new Waiter(i));
            }
            return list;
        }
        public async Task PlaceOrders()
        {
            Console.WriteLine("Place your order... (client, meal, waiting time => optional (seconds))");
            var order = Console.ReadLine().Split(',');
            if (order.Length > 2)
            {
                if (Int32.Parse(order[2]) >= Menu.Meals[Int32.Parse(order[1])].TimeToMake)
                    throw new TimeoutException("Cant make a meal for you... Your waiting time exedes our preparation time.");
            }
            var client = Clients.FirstOrDefault(o => o.Id == Int32.Parse(order[0]));
            client.Order = Menu.Meals[Int32.Parse(order[1])];
            await AskForNextOrder();
        }

        public async Task StartTheRestaurant()
        {
            Queue<Meal> ordersList = new Queue<Meal>{ };
            List<Task> tasks = new List<Task> { };
            foreach (var item in Clients)
            {
                if (item.Order != null)
                    ordersList.Enqueue(item.Order);
            }
            while (ordersList.Count != 0) 
            {
                foreach (var chef in Chefs)
                {
                    if (!chef.Working)
                    {
                        var order = ordersList.Dequeue();
                        tasks.Add(chef.PrepareTheMeal(order));
                        chef.FinishedMealEvent += Chef_FinishedMealEvent;
                    }
                }
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("All meals done... Closing restaurant...");
        }

        private async Task CallWaiter()
        {
            foreach (Waiter waiter in Waiters)
            {
                if (!waiter.Working)
                {
                    if (finished.Count != 0)
                    {
                        var deliver = finished.Dequeue(); // usuwa dwa?!
                        waiter.Deliver(deliver);
                    }
                }
            }
            if (finished.Count != 0)
                CallWaiter();
        }

        private void Chef_FinishedMealEvent(object sender, Meal e)
        {
            finished.Enqueue(e);
            CallWaiter();
        }

        public async Task AskForNextOrder()
        {
            Console.WriteLine("\nPlace next order?");
            var key = Console.ReadKey().KeyChar;
            switch (key)
            {
                case 'y':
                    await PlaceOrders();
                    break;
                case 'n':
                    await StartTheRestaurant ();
                    break;
                default:
                    Console.WriteLine("Wrong key pressed please try again.");
                    await AskForNextOrder();
                    break;
            }
        }
    }
}
