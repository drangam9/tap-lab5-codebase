using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    // dotnet ef migrations add Initial
    // dotnet ef database update
    public class MyDbContext : DbContext
    {
        //private readonly string _windowsConnectionString = @"Server=.\SQLExpress;Database=Lab5Database1;Trusted_Connection=True;TrustServerCertificate=true";
        private readonly string _windows2ConnectionString = "Data Source=DESKTOP-9JJKNRC;Database=Lab5Database1;Integrated Security = True; Connect Timeout = 30; Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False";
        //private readonly string _windows3ConnectionString = @"Data Source=NBKR004513;Initial Catalog=Lab5Database1;Integrated Security=True;TrustServerCertificate=True";

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_windows2ConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<User>().HasData(new User(new Guid("3F2504E0-4F89-41D3-9A0C-0305E82C3301"), "John", "john@email.com", "**********", new Guid("D39EA4FD-2900-4CE6-A81E-8FED108FE5E7"), new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA")));
            builder.Entity<Profile>().HasData(new Profile(new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"), "John's profile", 2, "This is John's profile", new Guid("3F2504E0-4F89-41D3-9A0C-0305E82C3301")));
            builder.Entity<UserType>().HasData(new UserType(new Guid("D39EA4FD-2900-4CE6-A81E-8FED108FE5E7"), "User"));
            builder.Entity<Subscription>().HasData(new Subscription(Guid.NewGuid(), "Basic", "Basic subscription", 10.00m));

            builder.Entity<User>()
                .HasOne(f => f.Type)
                .WithMany(c => c.Users)
                .HasForeignKey(f => f.TypeId);

            builder.Entity<Profile>()
                .HasOne(f => f.User)
                .WithOne(c => c.Profile)
                .HasForeignKey<Profile>(f => f.UserId);
            builder.Entity<Subscription>()
                .HasMany(f => f.Users)
                .WithMany(c => c.Subscriptions)
                .UsingEntity(j => j.ToTable("SubscriptionUser"));
        }
    }
}
