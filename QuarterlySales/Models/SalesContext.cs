using Microsoft.EntityFrameworkCore;

namespace QuarterlySales.Models
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) 
            : base(options) 
        { }

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Sales> Sales { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add seed employee
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Michael",
                    LastName = "Jordan",
                    DOB = new DateTime(1963, 2, 17),
                    DateOfHire = new DateTime(1995, 1, 1),
                    ManagerId = 0 //has no manager
                }
            );
        }
    }
}
