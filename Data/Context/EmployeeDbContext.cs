using Employee_HW_EF.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Employee_HW_EF.Context
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
