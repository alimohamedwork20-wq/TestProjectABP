using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TestProjectABP.Brands
{
    public interface IbrandAppService : ICrudAppService<BrandDto,Guid,PagedAndSortedResultRequestDto, CreateUpdateBrandDto>
    {
    }
}
