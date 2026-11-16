using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class TransferOrderDetail
    {
        public int TransferDetailId { get; set; }

        public int TransferOrderId { get; set; }

        public int ItemId { get; set; }

        public decimal RequestedQuantity { get; set; }

        public decimal DispatchedQuantity { get; set; }

        public decimal ReceivedQuantity { get; set; }


        // Navigation Properties
        public TransferOrder TransferOrder { get; set; } = null!;

        public Item Item { get; set; } = null!;
    }
}


