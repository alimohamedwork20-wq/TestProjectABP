using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TestProjectABP.Brands;
using TestProjectABP.Categories;
using TestProjectABP.Suppliers;
using Volo.Abp.Domain.Entities.Auditing;

namespace TestProjectABP.Products
{
    public class Product : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public int StockQuantity { get; set; } 
        public Guid BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public Guid? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }
        public Product()
        {
        }
        public Product(string name, decimal price, int stockQuantity, Guid? id = null) : base(id?? Guid.NewGuid())
        {
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
        }

    }
}
