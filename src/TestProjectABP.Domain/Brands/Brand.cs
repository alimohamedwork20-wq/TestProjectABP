using System;
using System.Collections.Generic;
using System.Text;
using TestProjectABP.Products;
using Volo.Abp.Domain.Entities.Auditing;

namespace TestProjectABP.Brands
{
    public class Brand : AuditedAggregateRoot<Guid>
    {
        public string Name{ get; set; }
        public string Description{ get; set; }
        public bool IsActive { get; set; }
 
        public ICollection<Product> Products { get; set; } = new List<Product>();

        protected Brand()
        {
        }

        public Brand(string name, string description, bool isActive, Guid? id = null) : base(id ?? Guid.NewGuid())
        {
            Name = name;
            Description = description;
            IsActive = isActive;
        }

    }
}
