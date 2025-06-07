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

        /*/// <summary>
        /// Used to configure the database connection and other options for the DbContext.
        /// This is another approach to configure the DbContext, apart from dependency injection.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("ConnectionStrings");
            base.OnConfiguring(optionsBuilder);
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
               .HasData(new Employee
               {
                   Id = 1,
                   Name = "John Doe",
                   Designation = "Software Engineer"
               },
               new Employee
               {
                   Id = 2,
                   Name = "Jane Smith",
                   Designation = "Project Manager"
               },
               new Employee
               {
                   Id = 3,
                   Name = "Alice Johnson",
                   Designation = "UX Designer"
               });

            modelBuilder.Entity<Contact>()
                .HasData(new Contact
                {
                    ContactId = 1,
                    MobileNumber = "123-456-7890",
                    EmailAddress = "jd@gmail.com",
                },
                new Contact
                {
                    ContactId = 2,
                    MobileNumber = "987-654-3210",
                    EmailAddress = "js@gmail.com",
                },
                new Contact
                {
                    ContactId = 3,
                    MobileNumber = "555-555-5555",
                    EmailAddress = "aj@gmail.com"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
