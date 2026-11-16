
namespace IMS.Entities.Inventory
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public int LeadTimeDays { get; set; }


        // Navigation Properties
        public ICollection<SupplierItem> SupplierItems { get; set; }
            = new List<SupplierItem>();
    }
}
