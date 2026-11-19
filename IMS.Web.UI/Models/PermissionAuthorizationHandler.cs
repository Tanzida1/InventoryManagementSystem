
using Microsoft.AspNetCore.Authorization;

namespace IMS.Web.UI.Models
{
    public class PermissionAuthorizationHandler
        : AuthorizationHandler<PermissionRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermissionRequirement requirement)
        {
            // Step 1: Check Administrator role
            if (context.User.IsInRole("Administrator"))
            {
                context.Succeed(requirement);

                return Task.CompletedTask;
            }

            // Step 2: Check permission for other roles
            var hasPermission = context.User.HasClaim(
                "Permission",
                requirement.PermissionName
            );

            if (hasPermission)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
