
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace IMS.Web.UI.Models
{
    public class PermissionPolicyProvider
        : DefaultAuthorizationPolicyProvider
    {
        private const string PolicyPrefix = "Permission:";

        public PermissionPolicyProvider(
            IOptions<AuthorizationOptions> options)
            : base(options)
        {
        }

        public override Task<AuthorizationPolicy?> GetPolicyAsync(
            string policyName)
        {
            if (policyName.StartsWith(
                PolicyPrefix,
                StringComparison.OrdinalIgnoreCase))
            {
                // Get the permission name
                var permissionName =
                    policyName.Substring(PolicyPrefix.Length);

                // Build permission policy
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddRequirements(
                        new PermissionRequirement(permissionName))
                    .Build();

                return Task.FromResult<AuthorizationPolicy?>(policy);
            }

            return base.GetPolicyAsync(policyName);
        }
    }
}
