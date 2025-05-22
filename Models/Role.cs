using Microsoft.EntityFrameworkCore;

namespace employee_and_unit_management_system.Models;

[PrimaryKey(nameof(Id))]
public class Role
{
    public int Id { get; set; }

    public required string Description { get; set; }

    public ICollection<User> Users { get; } = [];
}