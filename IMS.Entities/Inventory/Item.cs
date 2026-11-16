
namespace IMS.Entities.Inventory
{
    public class Item
    {
        public int ItemId { get; set; }

        public string ItemCode { get; set; } = string.Empty;

        public string ItemName { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public int UnitId { get; set; }

        public decimal UnitCost { get; set; }

        public decimal SellingPrice { get; set; }

        public decimal ReorderLevel { get; set; }


        // Navigation Properties
        public Category Category { get; set; } = null!;

        public Unit Unit { get; set; } = null!;

        public ICollection<SupplierItem> SupplierItems { get; set; }
            = new List<SupplierItem>();
    }
}
