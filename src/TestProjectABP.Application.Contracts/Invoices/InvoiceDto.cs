using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace TestProjectABP.Invoices
{
    public class InvoiceDto : FullAuditedEntityDto<Guid>
    {
        public string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public InvoiceStatusEnum Status { get; set; } = InvoiceStatusEnum.Draft;
        public List<InvoiceItemDto> Items { get; set; } = new List<InvoiceItemDto>();
    }
}
