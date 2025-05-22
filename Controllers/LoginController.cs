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
    public IActionResult Login()
    {
        return View();
    }

    // POST: Login
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Authenticate([Bind("Login,Password")] User user)
    {
        var existingUser = await _context.User.Where(x => x.Login == user.Login && x.Password == ).FirstOrDefaultAsync();
        if (existingUser == null)
        {
            return NotFound(new { message = "Usuário ou senha inválidos" });
        }

        var token = TokenService.GenerateToken(user);

        user.Password = "";

        if (ModelState.IsValid)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }
}