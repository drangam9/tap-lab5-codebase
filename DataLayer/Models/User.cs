namespace DataLayer.Models
{
    public class User
    {
        public User(string name, string email, string password, Guid typeId, Guid profileId)
        {
            Name = name;
            Email = email;
            Password = password;
            TypeId = typeId;
            ProfileId = profileId;
        }
        public User(Guid id, string name, string email, string password, Guid typeId, Guid profileId)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            TypeId = typeId;
            ProfileId = profileId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid TypeId { get; set; }
        public UserType Type { get; set; }
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
        public ICollection<Subscription>? Subscriptions { get; }
    }
}
