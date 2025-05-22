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

        public DbSet<employee_and_unit_management_system.Models.User> User { get; set; } = default!;
        public DbSet<employee_and_unit_management_system.Models.Unit> Unit { get; set; } = default!;
        public DbSet<employee_and_unit_management_system.Models.Collaborator> Collaborator { get; set; } = default!;
    }
}
