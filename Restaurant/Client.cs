namespace Restaurant
{
    class Client
    {
        public int Id { get; set; }
        public Meal Order { get; set; }
        public Client(int id)
        {
            Id = id;
        }
    }
}