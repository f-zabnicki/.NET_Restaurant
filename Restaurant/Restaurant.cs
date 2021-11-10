﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Restaurant
    {
        public List<Client> Clients { get; set; }
        public List<Chef> Chefs { get; set; }
        public List<Waiter> Waiters { get; set; }
        public Menu Menu { get; set; }
        public Restaurant(int clients, int chefs, int waiters)
        {
            Clients = CreateListOfClients(clients);
            Chefs = CreateListOfChefs(chefs);
            Waiters = CreateListOfWaiters(waiters);
            Menu = new Menu();
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
        public void PlaceOrders()
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
        }

        public async Task StartTheRestaurant()
        {
            await Chefs[0].PrepareTheMeal(Clients[0].Order);
            Console.WriteLine("Finish");
        }

        public void AskForNextOrder()
        {
            Console.WriteLine("Place next order?");
            var key = Console.ReadKey().KeyChar;
            switch (key)
            {
                case 'y':
                    PlaceOrders();
                    break;
                case 'n':
                    StartTheRestaurant();
                    break;
                default:
                    Console.WriteLine("Wrong key pressed please try again.");
                    AskForNextOrder();
                    break;
            }
        }
    }
}
