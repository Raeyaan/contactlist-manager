using Microsoft.EntityFrameworkCore;

namespace ContactList.Models
{

    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 4,
                    FirstName = "John",
                    LastName = "Smith",
                    Phone = "456-478-159",
                    Email = "n7lO5@example.com",
                    CategoryId = 1,
                    Created= new DateTime(2015, 12, 31, 5, 10, 20)
        },
                new Contact
                {
                    ContactId = 2,
                    FirstName = "Alice",
                    LastName = "Ross",
                    Phone = "789-657-719",
                    Email = "n7lO6@example.com",
                    CategoryId = 2,
                    Created = new DateTime(2015, 12, 31, 5, 10, 20)
        },
                new Contact
                {
                    ContactId = 3,
                    FirstName = "Chris",
                    LastName = "Lewis",
                    Phone = "196-746-319",
                    Email = "n7lO7@example.com",
                    CategoryId = 3,
                    Created = new DateTime(2015, 12, 31, 5, 10, 20)
    }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Friend" },
                new Category { CategoryId = 2, Name = "Family" },
                new Category { CategoryId = 3, Name = "Work" }
              
            );
        }
    }
}