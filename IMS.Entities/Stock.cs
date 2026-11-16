
namespace IMS.Entities.Inventory
{
    public class Stock
    {
        public int StockId { get; set; }

        public int ItemId { get; set; }

        public int WarehouseId { get; set; }

        public decimal QuantityOnHand { get; set; } = 0;

        public decimal QuantityReserved { get; set; } = 0;


        // Navigation Properties
        public Item Item { get; set; } = null!;

        public Warehouse Warehouse { get; set; } = null!;
    }
}
