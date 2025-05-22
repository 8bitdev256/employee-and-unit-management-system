using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employee_and_unit_management_system.Models;

[PrimaryKey(nameof(Id))]
public class User
{
    public int Id { get; set; }

    public required string Login { get; set; }

    public required string Password { get; set; }

    public bool Active { get; set; }

    public required int RoleId { get; set; }
}