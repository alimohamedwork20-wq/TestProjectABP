using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace TestProjectABP.Invoices
{
    public class Invoice : AuditedAggregateRoot<Guid>
    {
        public string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; private set; } = 0;
        public InvoiceStatusEnum Status { get; private set; } = InvoiceStatusEnum.Draft;
        public IReadOnlyCollection<InvoiceItem> Items => InvoiceItems;
        private readonly List<InvoiceItem> InvoiceItems = new List<InvoiceItem>();

        public Invoice() { }

        public Invoice(string invoiceNumber, Guid? id = null) : base(id?? Guid.NewGuid())
        {
            InvoiceNumber = invoiceNumber;
        }
        public void AddAsync(string Description, decimal UnitPrice, int quantity)
        {
            if (Status == InvoiceStatusEnum.Draft)
            {
                var item = new InvoiceItem(Description, UnitPrice, quantity);
                InvoiceItems.Add(item);
                TotalAmount += item.TotalPrice;
            }
            else { throw new UserFriendlyException("Cannot add items to a non-draft invoice!"); }
            
        }
        public void Pay()
        {
            if (Status == InvoiceStatusEnum.Cancelled)
            {
                throw new UserFriendlyException("ما ينفعش تدفع فاتورة ملغاة!");
            }

            Status = InvoiceStatusEnum.Paid;
            AddLocalEvent(new InvoicePaidEventData(Id, TotalAmount) );
        }
        public void Cancel()
        {
            if (Status == InvoiceStatusEnum.Paid)
            {
                throw new UserFriendlyException("ما ينفعش تلغي فاتورة مدفوعة خلاص!");
            }

            Status = InvoiceStatusEnum.Cancelled;
        }

    }
}
