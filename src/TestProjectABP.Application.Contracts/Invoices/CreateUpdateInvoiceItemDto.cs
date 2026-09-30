using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectABP.Invoices
{
    public class CreateUpdateInvoiceItemDto
    {
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
