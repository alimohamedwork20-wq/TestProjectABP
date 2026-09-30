using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TestProjectABP.Products;
using Volo.Abp.Domain.Entities.Auditing;

namespace TestProjectABP.Suppliers
{
    public class Supplier : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public Supplier() { }

        public Supplier(Guid? id, string name, string phoneNumber) : base(id?? Guid.NewGuid())
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
