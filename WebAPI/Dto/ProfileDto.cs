namespace WebAPI.Dto
{
    public class ProfileDto
    {
        public string Name { get; set; }
        public int Followers { get; set; }
        public string Bio { get; set; }
        public Guid UserId { get; set; }
    }
}

