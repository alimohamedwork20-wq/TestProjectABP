using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
namespace TestProjectABP.Products
{
    public class ProductAppService : CrudAppService<Product, ProductDto, Guid, GetProductsInputDto, CreateUpdateProductDto>, IProductAppService
    {
        public ProductAppService(IRepository<Product, Guid> repository)
            : base(repository)
        {
        }

        public override async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            var entity = await MapToEntityAsync(input);
            await Repository.InsertAsync(entity, autoSave: true);

            var productWithIncludes = await GetEntityByIdAsync(entity.Id);
            return await MapToGetOutputDtoAsync(productWithIncludes);
        }
        protected override async Task<IQueryable<Product>> CreateFilteredQueryAsync(GetProductsInputDto input)
        {
            return (await base.CreateFilteredQueryAsync(input))
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), x => x.Name.Contains(input.Filter))
                .WhereIf(input.MinPrice.HasValue, x => x.Price >= input.MinPrice)
                .WhereIf(input.MaxPrice.HasValue, x => x.Price <= input.MaxPrice)
                .WhereIf(input.CategoryId.HasValue, x => x.CategoryId == input.CategoryId)
                .WhereIf(input.BrandId.HasValue, x => x.BrandId == input.BrandId)
                .WhereIf(input.SupplierId.HasValue, x => x.SupplierId == input.SupplierId);
        }
        protected override async Task<Product> GetEntityByIdAsync(Guid id)
        {
            return await (await Repository.GetQueryableAsync())
                .Include(x => x.Brand)
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
