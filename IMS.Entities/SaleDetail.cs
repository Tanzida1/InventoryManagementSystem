using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class SaleDetail
    {
        public int SaleDetailId { get; set; }

        public int SaleId { get; set; }

        public int ItemId { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal SubTotal { get; set; }


        // Navigation Properties
        public Sale Sale { get; set; } = null!;

        public Item Item { get; set; } = null!;
    }
}
