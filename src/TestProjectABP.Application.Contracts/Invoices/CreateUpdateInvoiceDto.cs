using System.Collections.Generic;

namespace TestProjectABP.Invoices
{
    public class CreateUpdateInvoiceDto
    {
        public string InvoiceNumber { get; set; }
        public List<CreateUpdateInvoiceItemDto> Items { get; set; } = new List<CreateUpdateInvoiceItemDto>();
    }
}
