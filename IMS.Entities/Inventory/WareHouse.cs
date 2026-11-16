using IMS.Entities.Access;

namespace IMS.Entities.Inventory
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }

        public string WarehouseCode { get; set; } = string.Empty;

        public string WarehouseName { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;


        // Navigation Properties
        public ICollection<UserWarehouse> UserWarehouses { get; set; }
    = new List<UserWarehouse>();
    }
}