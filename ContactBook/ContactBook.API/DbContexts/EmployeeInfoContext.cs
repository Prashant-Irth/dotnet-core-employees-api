using ContactBook.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.API.DbContexts
{
    /// <summary>
    /// LOCAL DATABASE SETUP STEPS:
    /// STEP 1: Create Entities (Employee, Contact) with required properties.
    /// STEP 2: Create DbContext (EmployeeInfoContext) with DbSet properties for each entity.
    /// STEP 3: Configure the DbContext in Program.cs to use SQLite with a connection string.
    /// STEP 4: Add migrations using the command "add-migration <MigrationName>"
    ///         e.g., add-migration EmployeeInfoDbInitialMigration.
    /// STEP 5: Update the database using the command "update-database".
    /// STEP 6: Ensure the database file (EmployeeInfo.db) is created in the project directory.
    /// STEP 7 (Optional): If in case any new entity is added or existing entity is modified, 
    ///         repeat steps 4 and 5 to update the database schema. 
    /// Step 8: Database Seeding - If you want to seed the database with initial data, 
    ///         override the OnModelCreating method in the DbContext. Add dummy data inside that method.
    /// Step 9: After seeding, run the command "add-migration <MigrationName>" again to create a new migration.
    ///         After that, run "update-database" to apply the changes to the database.
    /// </summary>
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
                    EmployeeId = 1,
                    ContactId = 1,
                    MobileNumber = "123-456-7890",
                    EmailAddress = "jd@gmail.com",
                },
                new Contact
                {
                    EmployeeId = 2,
                    ContactId = 2,
                    MobileNumber = "987-654-3210",
                    EmailAddress = "js@gmail.com",
                },
                new Contact
                {
                    EmployeeId = 3,
                    ContactId = 3,
                    MobileNumber = "555-555-5555",
                    EmailAddress = "aj@gmail.com"
                });
        }
    }
}
