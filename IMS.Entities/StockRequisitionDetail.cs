
using IMS.Entities.Inventory;

namespace IMS.Entities
{
    public class StockRequisitionDetail
    {
        public int RequisitionDetailId { get; set; }

        public int RequisitionId { get; set; }

        public int ItemId { get; set; }

        public decimal RequestedQuantity { get; set; }

        public decimal ApprovedQuantity { get; set; }


        // Navigation Properties
        public StockRequisition StockRequisition { get; set; } = null!;

        public Item Item { get; set; } = null!;

        public ICollection<IssueOrderDetail> IssueOrderDetails { get; set; }
            = new List<IssueOrderDetail>();
    }
}
