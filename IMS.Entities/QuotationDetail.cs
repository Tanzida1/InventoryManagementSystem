using IMS.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Text;


namespace IMS.Entities
{
    public class QuotationDetail
    {
        public int QuotationDetailId { get; set; }

        public int QuotationId { get; set; }

        public int ItemId { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal QuotedQuantity { get; set; }


        // Navigation Properties
        public Quotation Quotation { get; set; } = null!;

        public Item Item { get; set; } = null!;
    }
}
