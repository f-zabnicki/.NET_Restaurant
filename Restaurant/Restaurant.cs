using System;
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
    }
}
