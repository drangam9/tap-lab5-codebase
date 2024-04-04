namespace DataLayer.Models
{
    public class Subscription
    {
        public Subscription(string name, string description, decimal price)
        {

            Name = name;
            Description = description;
            Price = price;
        }
        public Subscription(Guid id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
