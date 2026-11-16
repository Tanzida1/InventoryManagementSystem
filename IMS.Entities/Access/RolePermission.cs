
namespace IMS.Entities.Access
{
    public class RolePermission
    {
        public int RolePermissionId { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }


        // Navigation Properties
        public Role Role { get; set; } = null!;

        public Permission Permission { get; set; } = null!;
    }
}
