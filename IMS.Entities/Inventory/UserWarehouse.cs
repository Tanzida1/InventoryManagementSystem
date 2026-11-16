
using IMS.Entities.Inventory;

namespace IMS.Entities.Access
{
    public class UserWarehouse
    {
        public int UserWarehouseId { get; set; }

        public int UserId { get; set; }

        public int WarehouseId { get; set; }


        // Navigation Properties
        public User User { get; set; } = null!;

        public Warehouse Warehouse { get; set; } = null!;
    }
}
