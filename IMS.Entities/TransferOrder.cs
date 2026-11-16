using IMS.Entities.Access;
using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class TransferOrder
    {
        public int TransferOrderId { get; set; }

        public string TransferNumber { get; set; } = string.Empty;

        public int SourceWarehouseId { get; set; }

        public int DestinationWarehouseId { get; set; }

        public int RequestedBy { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public int? DispatchedBy { get; set; }

        public DateTime? DispatchedAt { get; set; }

        public int? ReceivedBy { get; set; }

        public DateTime? ReceivedAt { get; set; }

        public string? Remarks { get; set; }


        // Navigation Properties
        public Warehouse SourceWarehouse { get; set; } = null!;

        public Warehouse DestinationWarehouse { get; set; } = null!;

        public User User { get; set; } = null!;

        public ICollection<TransferOrderDetail> TransferOrderDetails { get; set; }
            = new List<TransferOrderDetail>();
    }
}
