using ContactBook.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.API.DbContexts
{
    public class EmployeeInfoContext : DbContext
    {
        public EmployeeInfoContext(DbContextOptions<EmployeeInfoContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
               .HasData(new Employee
               {
                   Id = Guid.NewGuid(),
                   Name = "John Doe",
                   Designation = "Software Engineer"
               },
               new Employee
               {
                   Id = Guid.NewGuid(),
                   Name = "Jane Smith",
                   Designation = "Project Manager"
               },
               new Employee
               {
                   Id = Guid.NewGuid(),
                   Name = "Alice Johnson",
                   Designation = "UX Designer"
               });

            modelBuilder.Entity<Contact>()
                .HasData(new Contact
                {
                    ContactId = Guid.NewGuid(),
                    MobileNumber = "123-456-7890",
                    EmailAddress = "jd@gmail.com",
                },
                new Contact
                {
                    ContactId = Guid.NewGuid(),
                    MobileNumber = "987-654-3210",
                    EmailAddress = "js@gmail.com",
                },
                new Contact
                {
                    ContactId = Guid.NewGuid(),
                    MobileNumber = "555-555-5555",
                    EmailAddress = "aj@gmail.com"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
