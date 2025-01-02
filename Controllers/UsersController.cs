using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Models.Entities;
using MVC.Services;

namespace MVC.Controllers;

public sealed class UsersController : Controller
{
    private readonly PSQLContext _databaseContext;
    
    public UsersController(PSQLContext context)
    {
        _databaseContext = context;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var users = await _databaseContext.Users.ToListAsync();
        return View(users);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return Json(new { success = false, message = "Form validation failed!" });
        }

        await _databaseContext.AddAsync(new User()
        {
            FirstName = model.FirstName,
            SecondName = model.SecondName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        });

        await _databaseContext.SaveChangesAsync();

        return Json(new { success = true, message = "Form submitted successfully!" });
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var user = await _databaseContext.Users.FindAsync(id);
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(User userModel)
    {
        var user = await _databaseContext.Users.FindAsync(userModel.Id);
        if(user != null)
        {
            user.FirstName = userModel.FirstName;
            user.SecondName = userModel.SecondName;
            user.Email = userModel.Email;
            user.PhoneNumber = userModel.PhoneNumber;

            await _databaseContext.SaveChangesAsync();
        }

        return RedirectToAction("List", "Users");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await _databaseContext.Users.FindAsync(id);
        if(user != null)
        {
            _databaseContext.Remove(user);
            await _databaseContext.SaveChangesAsync();
        }

        return RedirectToAction("List", "Users");
    }

}
