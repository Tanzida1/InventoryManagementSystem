
namespace IMS.Entities.Inventory
{
    public class SupplierItem
    {
        public int SupplierItemId { get; set; }

        public int SupplierId { get; set; }

        public int ItemId { get; set; }

        public string SupplierItemCode { get; set; } = string.Empty;

        public decimal LastQuotedPrice { get; set; }


        // Navigation Properties
        public Supplier Supplier { get; set; } = null!;

        public Item Item { get; set; } = null!;
    }
}
