using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TestProjectABP.Products;
using Volo.Abp.Domain.Entities.Auditing;

namespace TestProjectABP.Categories
{
    public class Category : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

        protected Category(){ }

        public Category( string name, string description, bool isActive, Guid? id = null) : base(id?? Guid.NewGuid())
        {
            Name = name;
            Description = description;
            IsActive = isActive;
        }
    }    
}
