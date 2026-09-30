using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TestProjectABP.Products
{
    public interface IProductAppService : ICrudAppService<ProductDto, Guid, GetProductsInputDto, CreateUpdateProductDto>
    {

    }
}
