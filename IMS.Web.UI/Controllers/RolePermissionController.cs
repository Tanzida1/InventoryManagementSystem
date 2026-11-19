
using IMS.Entities.Access;
using IMS.Facade.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Web.UI.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RolePermissionController : Controller
    {
        private readonly IRoleFacade _roleFacade;
        private readonly IPermissionFacade _permissionFacade;
        private readonly IRolePermissionFacade _rolePermissionFacade;

        public RolePermissionController(
            IRoleFacade roleFacade,
            IPermissionFacade permissionFacade,
            IRolePermissionFacade rolePermissionFacade)
        {
            _roleFacade = roleFacade;
            _permissionFacade = permissionFacade;
            _rolePermissionFacade = rolePermissionFacade;
        }

        // Show Roles
        public async Task<IActionResult> Index()
        {
            var roles = await _roleFacade.GetAllAsync();

            // Administrator does not need permission assignment
            var assignableRoles = roles
                .Where(x => !string.Equals(
                    x.RoleName,
                    "Administrator",
                    StringComparison.OrdinalIgnoreCase))
                .ToList();

            return View(assignableRoles);
        }





        // Assign Permissions - GET
        [HttpGet]
        public async Task<IActionResult> Assign(int roleId)
        {
            var role = await _roleFacade.GetByIdAsync(roleId);

            if (role == null)
                return NotFound();

            // Administrator role cannot receive manual permissions
            if (string.Equals(
                role.RoleName,
                "Administrator",
                StringComparison.OrdinalIgnoreCase))
            {
                return Forbid();
            }

            var permissions = await _permissionFacade.GetAllAsync();

            var rolePermissions =
                await _rolePermissionFacade.GetAllAsync();

            var selectedPermissionIds = rolePermissions
                .Where(x => x.RoleId == roleId)
                .Select(x => x.PermissionId)
                .ToList();

            var model = new RolePermissionViewModel
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                Permissions = permissions,
                SelectedPermissionIds = selectedPermissionIds
            };

            return View(model);
        }

        // Assign Permissions - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Assign(
     RolePermissionViewModel model)
        {
            var role = await _roleFacade.GetByIdAsync(model.RoleId);

            if (role == null)
                return NotFound();

            // Prevent assigning permissions to Administrator
            if (string.Equals(
                role.RoleName,
                "Administrator",
                StringComparison.OrdinalIgnoreCase))
            {
                return Forbid();
            }

            var allPermissions = await _permissionFacade.GetAllAsync();

            var validPermissionIds = allPermissions
                .Where(x => x.IsActive)
                .Select(x => x.PermissionId)
                .ToHashSet();

            var selectedIds = (model.SelectedPermissionIds ?? new List<int>())
                .Distinct()
                .ToList();

            if (selectedIds.Any(x => !validPermissionIds.Contains(x)))
            {
                ModelState.AddModelError(
                    "",
                    "One or more selected permissions are invalid or inactive.");

                model.RoleName = role.RoleName;
                model.Permissions = allPermissions;

                return View(model);
            }

            var existingRolePermissions =
                await _rolePermissionFacade.GetAllAsync();

            var currentAssignments = existingRolePermissions
                .Where(x => x.RoleId == model.RoleId)
                .ToList();

            // Remove permissions that are no longer selected
            foreach (var existing in currentAssignments)
            {
                if (!selectedIds.Contains(existing.PermissionId))
                {
                    await _rolePermissionFacade.DeleteAsync(
                        existing.RolePermissionId);
                }
            }

            // Add newly selected permissions
            var currentPermissionIds = currentAssignments
                .Select(x => x.PermissionId)
                .ToHashSet();

            foreach (var permissionId in selectedIds)
            {
                if (!currentPermissionIds.Contains(permissionId))
                {
                    await _rolePermissionFacade.AddAsync(
                        new RolePermission
                        {
                            RoleId = model.RoleId,
                            PermissionId = permissionId
                        });
                }
            }

            TempData["SuccessMessage"] =
                "Role permissions updated successfully.";

            return RedirectToAction(nameof(Index));
        }


















        public class RolePermissionViewModel
        {
            public int RoleId { get; set; }

            public string RoleName { get; set; } = string.Empty;

            public List<int> SelectedPermissionIds { get; set; }
                = new List<int>();

            public List<Permission> Permissions { get; set; }
                = new List<Permission>();
        }
    }

}
