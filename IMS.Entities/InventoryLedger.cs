using IMS.Entities.Access;
using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Entities
{
    public class InventoryLedger
    {
        public int LedgerId { get; set; }

        public int ItemId { get; set; }

        public int WarehouseId { get; set; }

        public string TransactionType { get; set; } = string.Empty;

        public decimal QuantityChange { get; set; }

        public string DocumentType { get; set; } = string.Empty;

        public int DocumentId { get; set; }

        public int? DocumentLineId { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public int? CreatedBy { get; set; }


        // Navigation Properties
        public Item Item { get; set; } = null!;

        public Warehouse Warehouse { get; set; } = null!;

        public User? User { get; set; }
    }
}
