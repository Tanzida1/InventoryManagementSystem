
using IMS.Entities.Access;
using IMS.Entities.Inventory;

namespace IMS.Entities
{
    public class IssueOrder
    {
        public int IssueOrderId { get; set; }

        public string IssueOrderNumber { get; set; } = string.Empty;

        public int RequisitionId { get; set; }

        public int WarehouseId { get; set; }

        public int IssuedBy { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime? IssuedDate { get; set; }


        // Navigation Properties
        public StockRequisition StockRequisition { get; set; } = null!;

        public Warehouse Warehouse { get; set; } = null!;

        public User User { get; set; } = null!;

        public ICollection<IssueOrderDetail> IssueOrderDetails { get; set; }
            = new List<IssueOrderDetail>();
    }
}
