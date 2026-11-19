
using IMS.Entities.Access;
using IMS.Facade.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IMS.Web.UI.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserFacade _userFacade;

        public UsersController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        // 1. Show all users
        [HttpGet]
        [Authorize(Policy = "Permission:User.View")]
        public async Task<IActionResult> Index()
        {
            var users = await _userFacade.GetAllAsync();

            return View(users);
        }


        // 2. Show Add User page
        [HttpGet]
        [Authorize(Policy = "Permission:User.Create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = await _userFacade.GetAllRolesAsync();

            return View(new User());
        }


        // 3. Save new user
        [HttpPost]
        [Authorize(Policy = "Permission:User.Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            string fullName,
            string email,
            string password,
            string confirmPassword,
            string roleName)
        {
            ViewBag.Roles = await _userFacade.GetAllRolesAsync();

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(roleName))
            {
                ViewBag.Error = "All fields are required.";
                return View(new User
                {
                    FullName = fullName ?? "",
                    Email = email ?? ""
                });
            }

            if (password.Length < 8)
            {
                ViewBag.Error = "Password must contain at least 8 characters.";

                return View(new User
                {
                    FullName = fullName,
                    Email = email
                });
            }

            if (password != confirmPassword)
            {
                ViewBag.Error = "Password and Confirm Password do not match.";

                return View(new User
                {
                    FullName = fullName,
                    Email = email
                });
            }

            var user = new User
            {
                FullName = fullName.Trim(),
                Email = email.Trim()
            };

            bool result = await _userFacade.RegisterAsync(
                user,
                password,
                roleName
            );

            if (!result)
            {
                ViewBag.Error = "This email already exists or the selected role is invalid.";

                return View(new User
                {
                    FullName = fullName,
                    Email = email
                });
            }

            TempData["SuccessMessage"] = "New user created successfully.";

            return RedirectToAction(nameof(Index));
        }


        // 4. Show Edit User page
        [HttpGet]
        [Authorize(Policy = "Permission:User.Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userFacade.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            ViewBag.Roles = await _userFacade.GetAllRolesAsync();

            return View(user);
        }


        // 5. Update user information and role
        [HttpPost]
        [Authorize(Policy = "Permission:User.Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            string fullName,
            string email,
            string roleName)
        {
            var user = await _userFacade.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            ViewBag.Roles = await _userFacade.GetAllRolesAsync();

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(roleName))
            {
                ViewBag.Error = "All fields are required.";
                return View(user);
            }

            email = email.Trim();

            // Check duplicate email
            var existingUser = await _userFacade.GetByEmailAsync(email);

            if (existingUser != null && existingUser.UserId != id)
            {
                ViewBag.Error = "This email is already used by another user.";
                return View(user);
            }

            // Check selected role exists
            var roles = await _userFacade.GetAllRolesAsync();

            if (!roles.Any(role => role.RoleName == roleName))
            {
                ViewBag.Error = "Selected role does not exist.";
                return View(user);
            }

            // Prevent changing own role
            var currentUserId = User.FindFirstValue(
                ClaimTypes.NameIdentifier
            );

            string? currentRole = user.UserRoles
                .FirstOrDefault()?.Role?.RoleName;

            if (currentUserId == id.ToString() &&
                currentRole != roleName)
            {
                ViewBag.Error = "You cannot change your own role.";
                return View(user);
            }

            // Update role first
            bool roleUpdated = await _userFacade.UpdateUserRoleAsync(
                id,
                roleName
            );

            if (!roleUpdated)
            {
                ViewBag.Error = "Role could not be updated. The last active Administrator cannot be removed.";
                return View(user);
            }

            // Update basic information
            user.FullName = fullName.Trim();
            user.Email = email;

            await _userFacade.UpdateAsync(user);

            TempData["SuccessMessage"] = "User updated successfully.";

            return RedirectToAction(nameof(Index));
        }


        // 6. Deactivate user
        [HttpPost]
        [Authorize(Policy = "Permission:User.Deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deactivate(int id)
        {
            var currentUserId = User.FindFirstValue(
                ClaimTypes.NameIdentifier
            );

            if (currentUserId == id.ToString())
            {
                TempData["ErrorMessage"] = "You cannot deactivate your own account.";

                return RedirectToAction(nameof(Index));
            }

            bool result = await _userFacade.SetActiveStatusAsync(
                id,
                false
            );

            TempData[result ? "SuccessMessage" : "ErrorMessage"] =
                result
                ? "User deactivated successfully."
                : "User could not be deactivated. Check whether this is the last active Administrator.";

            return RedirectToAction(nameof(Index));
        }


        // 7. Activate user
        [HttpPost]
        [Authorize(Policy = "Permission:User.Activate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Activate(int id)
        {
            bool result = await _userFacade.SetActiveStatusAsync(
                id,
                true
            );

            TempData[result ? "SuccessMessage" : "ErrorMessage"] =
                result
                ? "User activated successfully."
                : "User could not be activated.";

            return RedirectToAction(nameof(Index));
        }
    }
}
