
using System;
using Volo.Abp.Application.Dtos;

namespace TestProjectABP.Products
{
    public class GetProductsInputDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }        // للبحث في اسم المنتج
        public decimal? MinPrice { get; set; }     // الحد الأدنى للسعر
        public decimal? MaxPrice { get; set; }     // الحد الأقصى للسعر
        public Guid? BrandId { get; set; }         // فلترة بالبراند
        public Guid? CategoryId { get; set; }      // فلترة بالتصنيف
        public Guid? SupplierId { get; set; }
    }
}
