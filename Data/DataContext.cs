using Microsoft.EntityFrameworkCore;
using employee_and_unit_management_system.Models;

namespace employee_and_unit_management_system.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Collaborator> Collaborator { get; set; } = default!;
        public DbSet<Unit> Unit { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;
        public DbSet<Role> Role { get; set; } = default!;
    }
}
