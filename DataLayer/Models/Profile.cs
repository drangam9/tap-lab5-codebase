namespace DataLayer.Models
{
    public class Profile
    {
        public Profile(string name, int followers, string bio, Guid userId)
        {

            Name = name;
            Followers = followers;
            Bio = bio;
            UserId = userId;
        }
        public Profile(Guid id, string name, int followers, string bio, Guid userId)
        {
            Id = id;
            Name = name;
            Followers = followers;
            Bio = bio;
            UserId = userId;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Followers { get; set; }
        public string Bio { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
