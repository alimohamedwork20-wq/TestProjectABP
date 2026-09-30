using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectABP.Invoices
{
    public class InvoicePaidEventData
    {
        public Guid InvoiceId { get; set; }
        public decimal TotalAmount { get; set; }
        public InvoicePaidEventData(Guid invoiceId, decimal totalAmount)
        {
            InvoiceId = invoiceId;
            TotalAmount = totalAmount;
        }
    }
}
