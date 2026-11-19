

using IMS.Facade.Interface;
using IMS.Entities.Access;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace IMS.Web.UI.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserFacade _userFacade;
        private readonly IRolePermissionFacade _rolePermissionFacade;
        private readonly IPermissionFacade _permissionFacade;

        public AuthenticationController(IUserFacade userFacade, IRolePermissionFacade rolePermissionFacade,
    IPermissionFacade permissionFacade)
        {
            _userFacade = userFacade;
            _rolePermissionFacade = rolePermissionFacade;
            _permissionFacade = permissionFacade;
        }


        [Authorize(Roles = "Administrator")]
        public IActionResult Users()
        {
            return View();
        }





        [Authorize(Roles = "Manager")]
        public IActionResult Approvals()
        {
            return View();
        }





        [Authorize(Roles = "Manager,Administrator")]
        public IActionResult Reports()
        {
            return View();
        }





        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ReturnUrl = returnUrl;

            return View();
        }



        //Login POST:

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(
    string email,
    string password,
    bool rememberMe = false,
    string? returnUrl = null)
        {
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Email and password are required.";
                ViewBag.Email = email;
                ViewBag.ReturnUrl = returnUrl;

                return View();
            }

            var user = await _userFacade.AuthenticateAsync(email, password);

            if (user == null)
            {
                ViewBag.Error = "Invalid email or password.";
                ViewBag.Email = email;
                ViewBag.ReturnUrl = returnUrl;

                return View();
            }

            // Create Claims
            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
        new Claim(ClaimTypes.Name, user.FullName),
        new Claim(ClaimTypes.Email, user.Email)
    };

            // Add User Roles
            foreach (var userRole in user.UserRoles)
            {
                if (userRole.Role != null)
                {
                    claims.Add(
                        new Claim(ClaimTypes.Role, userRole.Role.RoleName)
                    );
                }
            }

            // Load User Role IDs
            var roleIds = user.UserRoles
                .Select(x => x.RoleId)
                .ToList();

            // Load Permissions assigned to those Roles
            var rolePermissions =
                await _rolePermissionFacade.GetAllAsync();

            var permissionIds = rolePermissions
                .Where(x => roleIds.Contains(x.RoleId))
                .Select(x => x.PermissionId)
                .Distinct()
                .ToList();

            // Load Permission Names
            var permissions = await _permissionFacade.GetAllAsync();

            foreach (var permission in permissions)
            {
                if (permissionIds.Contains(permission.PermissionId)
                    && permission.IsActive)
                {
                    claims.Add(
                        new Claim("Permission", permission.PermissionName)
                    );
                }
            }




            // Create Identity
            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            // Create Principal
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Cookie Properties
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2)
            };

            // Create Authentication Cookie
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                authProperties
            );

            // Redirect after successful login
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }



        //Logout

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            return RedirectToAction("Login", "Authentication");
        }




        // First Administrator Setup Page
        //[HttpGet]
        //public async Task<IActionResult> Register()
        //{
        //    var users = await _userFacade.GetAllAsync();

        //    if (users.Any())
        //    {
        //        ViewBag.SetupClosed = true;
        //    }

        //    return View(new RegistrationViewModel());
        //}

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            var users = await _userFacade.GetAllAsync();

            ViewBag.IsFirstUser = !users.Any();

            return View(new RegistrationViewModel());
        }


        // Create First Administrator
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(
        //    RegistrationViewModel model)
        //{
        //    // Check whether the form data is valid
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        // Check whether a user already exists

        //var users = await _userFacade.GetAllAsync();

        //if (users.Any())
        //{
        //    ViewBag.SetupClosed = true;
        //    return View(model);
        //}


        // Create User object
        //    var user = new User
        //    {
        //        FullName = model.FullName.Trim(),
        //        Email = model.Email.Trim(),
        //        IsActive = true
        //    };

        //    // Register the first Administrator
        //    try
        //    {
        //        bool isRegistered = await _userFacade.RegisterAsync(
        //            user,
        //            model.Password,
        //            "Administrator");

        //        if (!isRegistered)
        //        {
        //            ModelState.AddModelError(
        //                nameof(model.Email),
        //                "This email is already registered.");

        //            return View(model);
        //        }

        //        ViewBag.SuccessMessage =
        //            "First Administrator account created successfully.";

        //        return View(new RegistrationViewModel());
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        ModelState.AddModelError(
        //            "",
        //            "Administrator role was not found. Please check the Roles table.");

        //        return View(model);
        //    }


        //}








        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(
    RegistrationViewModel model)
        {
            var users = await _userFacade.GetAllAsync();

            bool isFirstUser = !users.Any();

            ViewBag.IsFirstUser = isFirstUser;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // First account becomes Administrator.
            // All later public registrations become Requester.
            string roleName = isFirstUser
                ? "Administrator"
                : "Requester";

            var user = new User
            {
                FullName = model.FullName.Trim(),
                Email = model.Email.Trim(),
                IsActive = true
            };

            try
            {
                bool isRegistered = await _userFacade.RegisterAsync(
                    user,
                    model.Password,
                    roleName
                );

                if (!isRegistered)
                {
                    ModelState.AddModelError(
                        nameof(model.Email),
                        "This email is already registered."
                    );

                    return View(model);
                }

                TempData["SuccessMessage"] =
                    isFirstUser
                    ? "Administrator account created successfully."
                    : "Account created successfully. You can now log in.";

                return RedirectToAction("Login", "Authentication");
            }
            catch (InvalidOperationException)
            {
                ModelState.AddModelError(
                    "",
                    $"The {roleName} role was not found. Please check the Roles table."
                );

                return View(model);
            }
        }













        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }










    }
}
