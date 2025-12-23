using Microsoft.EntityFrameworkCore;
using TestApp.Infrastructure.Entities;

namespace TestApp.Infrastructure.Context
{
    public class TestAppDbContext : DbContext
    {
        public TestAppDbContext(DbContextOptions<TestAppDbContext> options) : base(options) { }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<Genders> Genders { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Clients>().Navigation(t => t.MaritalStatus).AutoInclude();
            modelBuilder.Entity<Clients>().Navigation(t => t.Genders).AutoInclude();           

            modelBuilder.Entity<Users>().HasData(
             new Users { Id = 1, LastName = "Cuéllar", Name = "Johans", Email = "admin@test.com",
                 UserName = "admin@test.com", Password = "3e0a3501a65b4a7bf889c6f180cc6e35747e5aaff931cc90b760671efa09aeac", State = true 
             }
            );            

            modelBuilder.Entity<MaritalStatus>().HasData(
                new MaritalStatus { Id = 1, Name = "Single" },
                new MaritalStatus { Id = 2, Name = "Married" }
            );

            modelBuilder.Entity<Genders>().HasData(
                new Genders { Id = 1, Name = "Male" },
                new Genders { Id = 2, Name = "Female" }
            );

            modelBuilder.Entity<Clients>().HasData(
              new Clients
              { Id = 1, DocumentId = 16870419, LastName = "Cuéllar", Name = "Johans", MaritalStatusId = 1, GendersId = 1, BirthDate = DateTime.Parse("17-05-1984") }
            );            
        }
    }
}
