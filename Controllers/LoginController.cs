using employee_and_unit_management_system.Data;
using employee_and_unit_management_system.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employee_and_unit_management_system.Controllers;

public class LoginController : Controller
{
    private readonly DataContext _context;

    public LoginController(DataContext context)
    {
        _context = context;
    }

    // GET: Login
    public IActionResult Authenticate()
    {
        return View();
    }

    // POST: Login
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Authenticate([Bind("Login,Password, RoleId")] User user)
    {
        var existingUser = await _context.User.Where(x => x.Login == user.Login && x.Password == user.Password).FirstOrDefaultAsync();
        if (existingUser == null)
        {
            return NotFound(new { message = "Usuário ou senha inválidos" });
        }

        var token = TokenService.GenerateToken(user);

        user.Password = "";

        return RedirectToAction("../Home/Index");
    }
}