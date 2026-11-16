using IMS.Entities.Access;
using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }

        public string InvoiceNumber { get; set; } = string.Empty;

        public int WarehouseId { get; set; }

        public int SalesOfficerId { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; }


        // Navigation Properties
        public Warehouse Warehouse { get; set; } = null!;

        public User User { get; set; } = null!;

        public ICollection<SaleDetail> SaleDetails { get; set; }
            = new List<SaleDetail>();
    }
}
