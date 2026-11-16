
namespace IMS.Entities.Access
{
    public class UserRole
    {
        public int UserRoleId { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }


        // Navigation Properties
        public User User { get; set; } = null!;

        public Role Role { get; set; } = null!;
    }
}
