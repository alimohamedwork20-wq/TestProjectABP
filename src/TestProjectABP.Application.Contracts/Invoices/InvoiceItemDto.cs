using System;
using Volo.Abp.Application.Dtos;

namespace TestProjectABP.Invoices
{
    public class InvoiceItemDto : EntityDto<Guid>
    {
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal TotalPrice { get; set; }
    }
}
