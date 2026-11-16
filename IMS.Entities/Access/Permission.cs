
namespace IMS.Entities.Access
{
    public class Permission
    {
        public int PermissionId { get; set; }

        public string PermissionName { get; set; } = string.Empty;


        // Navigation Properties
        public ICollection<RolePermission> RolePermissions { get; set; }
            = new List<RolePermission>();
    }
}
