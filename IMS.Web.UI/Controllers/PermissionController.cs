
using IMS.Entities.Access;
using IMS.Facade.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
namespace IMS.Web.UI.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class PermissionController : Controller
    {
        private readonly IPermissionFacade _permissionFacade;

        public PermissionController(IPermissionFacade permissionFacade)
        {
            _permissionFacade = permissionFacade;
        }

        // 1. Show all permissions
        public async Task<IActionResult> Index()
        {
            var permissions = await _permissionFacade.GetAllAsync();
            return View(permissions);
        }

        // 2. Create Permission - GET
        public async Task<IActionResult> Create()
        {
           // await LoadParentPermissions();
            return View();
        }

        // 3. Create Permission - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("PermissionName,DisplayText,IsActive")]//ParentId,
            Permission permission)
        {
            if (!ModelState.IsValid)
            {
               // await LoadParentPermissions(permission.ParentId);
                return View(permission);
            }

            await _permissionFacade.AddAsync(permission);

            return RedirectToAction(nameof(Index));
        }

        // 4. Edit Permission - GET
        public async Task<IActionResult> Edit(int id)
        {
            var permission = await _permissionFacade.GetByIdAsync(id);

            if (permission == null)
                return NotFound();

           //await LoadParentPermissions(permission.ParentId, id);

            return View(permission);
        }

        // 5. Edit Permission - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("PermissionId,PermissionName,DisplayText,IsActive")]//ParentId,
            Permission permission)
        {
            if (id != permission.PermissionId)
                return NotFound();

            if (!ModelState.IsValid)
            {
               // await LoadParentPermissions(permission.ParentId, id);
                return View(permission);
            }

            var existingPermission =
                await _permissionFacade.GetByIdAsync(id);

            if (existingPermission == null)
                return NotFound();

            //existingPermission.ParentId = permission.ParentId;
            existingPermission.PermissionName = permission.PermissionName;
            existingPermission.DisplayText = permission.DisplayText;
            existingPermission.IsActive = permission.IsActive;

            await _permissionFacade.UpdateAsync(existingPermission);

            return RedirectToAction(nameof(Index));
        }

        // 6. Delete Permission - GET
        public async Task<IActionResult> Delete(int id)
        {
            var permission = await _permissionFacade.GetByIdAsync(id);

            if (permission == null)
                return NotFound();

            return View(permission);
        }

        // 7. Delete Permission - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permission = await _permissionFacade.GetByIdAsync(id);

            if (permission == null)
                return NotFound();

            await _permissionFacade.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        // Load Parent Permissions
        //private async Task LoadParentPermissions(
        //    int? selectedParentId = null,
        //    int? excludePermissionId = null)
        //{
        //    var permissions = await _permissionFacade.GetAllAsync();

        //    if (excludePermissionId.HasValue)
        //    {
        //        permissions = permissions
        //            .Where(x => x.PermissionId != excludePermissionId.Value)
        //            .ToList();
        //    }

        //    ViewBag.ParentPermissions = new SelectList(
        //        permissions,
        //        "PermissionId",
        //        "PermissionName",
        //        selectedParentId
        //    );
        //}
    }
}
