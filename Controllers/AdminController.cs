using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using InventorySystem.Models;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IActionResult> Index()
    {
        var users = _userManager.Users.ToList();
        var roles = _roleManager.Roles
            .Where(r => r.Name != null)
            .Select(r => r.Name!)
            .ToList();

        var model = new List<UserRoleViewModel>();

        foreach (var user in users)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            model.Add(new UserRoleViewModel
            {
                UserId = user.Id,
                Email = user.Email ?? "",
                Roles = userRoles.ToList(),
                AvailableRoles = roles
            });
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateRole(string userId, string selectedRole)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null || string.IsNullOrWhiteSpace(selectedRole)) return RedirectToAction("Index");

        var userRoles = await _userManager.GetRolesAsync(user);

        // Remove all roles
        await _userManager.RemoveFromRolesAsync(user, userRoles);

        // Add selected role
        await _userManager.AddToRoleAsync(user, selectedRole);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult CreateUser()
    {
        var model = new CreateUserViewModel
        {
            AvailableRoles = _roleManager.Roles
                .Where(r => r.Name != null)
                .Select(r => r.Name!)
                .ToList()
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.AvailableRoles = _roleManager.Roles
                .Where(r => r.Name != null)
                .Select(r => r.Name!)
                .ToList();
            return View(model);
        }

        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, model.Role);
            return RedirectToAction("Index");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        model.AvailableRoles = _roleManager.Roles
            .Where(r => r.Name != null)
            .Select(r => r.Name!)
            .ToList();
        return View(model);
    }
}
