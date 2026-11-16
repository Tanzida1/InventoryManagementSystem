
using IMS.Entities.Inventory;

namespace IMS.Entities
{
    public class IssueOrderDetail
    {
        public int IssueOrderDetailId { get; set; }

        public int IssueOrderId { get; set; }

        public int RequisitionDetailId { get; set; }

        public int ItemId { get; set; }

        public decimal IssuedQuantity { get; set; }


        // Navigation Properties
        public IssueOrder IssueOrder { get; set; } = null!;

        public StockRequisitionDetail StockRequisitionDetail { get; set; } = null!;

        public Item Item { get; set; } = null!;
    }
}
