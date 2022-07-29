using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Position> Position { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<UserInfo>? UserInfos { get; set; }

    }
}
