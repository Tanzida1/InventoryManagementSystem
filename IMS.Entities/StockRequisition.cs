
using IMS.Entities.Access;
using IMS.Entities.Inventory;

namespace IMS.Entities
{
    public class StockRequisition
    {
        public int RequisitionId { get; set; }

        public string RequisitionNumber { get; set; } = string.Empty;

        public int RequesterId { get; set; }

        public int WarehouseId { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public string? Remarks { get; set; }


        // Navigation Properties
        public User User { get; set; } = null!;

        public Warehouse Warehouse { get; set; } = null!;

        public ICollection<StockRequisitionDetail> RequisitionDetails { get; set; }
            = new List<StockRequisitionDetail>();

        public ICollection<IssueOrder> IssueOrders { get; set; }
            = new List<IssueOrder>();
    }
}
