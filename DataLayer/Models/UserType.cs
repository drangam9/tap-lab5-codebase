namespace DataLayer.Models
{
    public class UserType
    {
        public UserType(string name)
        {
            Name = name;
            Users = new List<User>();
        }
        public UserType(Guid id, string name)
        {
            Id = id;
            Name = name;
            Users = new List<User>();
        }
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
