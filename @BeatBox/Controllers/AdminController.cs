using _BeatBox.Areas.Identity.Data;
using _BeatBox.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _BeatBox.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AdminController> _logger;

        public AdminController(UserManager<Users> userManager,
                               RoleManager<IdentityRole> roleManager,
                               ILogger<AdminController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        public IActionResult UserList()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        public async Task<IActionResult> AdminPanel()
        {
            var users = _userManager.Users.ToList();
            

            // Optionally, create a view model to send additional data
            var model = new List<UserViewModel>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();
                model.Add(new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Roles = roles.ToList(),
                    AvailableRoles = allRoles.Select(role => new SelectListItem
                    {
                        Value = role,
                        Text = role,
                        Selected = roles.Contains(role)
                    }).ToList()
                });
            }

            return View(model);
        }
        public async Task<IActionResult> UserView(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);

            var model = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = roles.ToList()
            };

            return View(model);
        }


        // [HttpPost]
        // GET: Admin/UserEdit/{id}
        public async Task<IActionResult> UserEdit(string id)
        {
            if (id == null)
            {
                _logger.LogWarning("User ID is null.");
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning($"User with ID {id} not found.");
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();

            var model = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = userRoles.ToList(),
                AvailableRoles = allRoles.Select(role => new SelectListItem
                {
                    Value = role,
                    Text = role,
                    Selected = userRoles.Contains(role)
                }).ToList()
            };

            _logger.LogInformation("Loaded user edit form for user: {UserId}", user.Id);

            return View(model);
        }

        // POST: Admin/UserEdit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserEdit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                {
                    _logger.LogWarning("User not found during edit: {UserId}", model.Id);
                    return NotFound();
                }

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;

                var updateResult = await _userManager.UpdateAsync(user);
                if (updateResult.Succeeded)
                {
                    _logger.LogInformation("Successfully updated user: {UserId}", user.Id);

                    var currentRoles = await _userManager.GetRolesAsync(user);
                    var selectedRoles = model.Roles ?? new List<string>();

                    var rolesToAdd = selectedRoles.Except(currentRoles).ToList();
                    var rolesToRemove = currentRoles.Except(selectedRoles).ToList();

                    if (rolesToAdd.Any())
                    {
                        var addResult = await _userManager.AddToRolesAsync(user, rolesToAdd);
                        if (!addResult.Succeeded)
                        {
                            foreach (var error in addResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                                _logger.LogError("Error adding roles: {Error}", error.Description);
                            }
                            model.AvailableRoles = _roleManager.Roles.Select(r => new SelectListItem
                            {
                                Value = r.Name,
                                Text = r.Name,
                                Selected = selectedRoles.Contains(r.Name)
                            }).ToList();
                            return View(model);
                        }
                    }

                    if (rolesToRemove.Any())
                    {
                        var removeResult = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
                        if (!removeResult.Succeeded)
                        {
                            foreach (var error in removeResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                                _logger.LogError("Error removing roles: {Error}", error.Description);
                            }
                            model.AvailableRoles = _roleManager.Roles.Select(r => new SelectListItem
                            {
                                Value = r.Name,
                                Text = r.Name,
                                Selected = selectedRoles.Contains(r.Name)
                            }).ToList();
                            return View(model);
                        }
                    }

                    return RedirectToAction(nameof(AdminPanel));
                }

                foreach (var error in updateResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    _logger.LogError("Error updating user: {Error}", error.Description);
                }
            }

            model.AvailableRoles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Value = r.Name,
                Text = r.Name,
                Selected = model.Roles.Contains(r.Name)
            }).ToList();

            return View(model);
        }




        // GET: Admin/UserDelete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserDelete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                _logger.LogInformation("Successfully deleted user: {UserId}", id);
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
                _logger.LogError("Error deleting user: {Error}", error.Description);
            }

            return View(); // Return a view or redirect as needed
        }

    }
}
