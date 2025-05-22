using employee_and_unit_management_system.Data;
using Microsoft.EntityFrameworkCore;

namespace employee_and_unit_management_system.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new DataContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<DataContext>>());

        if (!context.Role.Any())
        {
            context.Role.AddRange(
                new Role
                {
                    Id = 1,
                    Description = "Administrator",
                },

                new Role
                {
                    Id = 2,
                    Description = "Default",
                }
            );
        }


        if (!context.User.Any())
        {
            context.User.Add(
                new User
                {
                    Login = "Admin",
                    Password = "Admin",
                    Active = true,
                    RoleId = 1,
                }
            );
        }
        
        context.SaveChanges();
    }
}