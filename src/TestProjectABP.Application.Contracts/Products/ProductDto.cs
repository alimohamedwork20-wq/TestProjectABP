using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace TestProjectABP.Products
{
    public class ProductDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; } // اسم البراند للعرض

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}
