using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace TestProjectABP.Invoices
{
    public class InvoiceItem : Entity<Guid>
    {
        public string Description { get; set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; set; } = 1;
        public decimal TotalPrice { get; private set; }

        public InvoiceItem(){ }
        public InvoiceItem(string description, decimal unitPrice, int quantity, Guid? id = null) : base(id ?? Guid.NewGuid())
        {
            Description = description;
            UnitPrice = unitPrice;
            Quantity = quantity;
            TotalPrice = quantity * unitPrice;
        }


    }
} 
