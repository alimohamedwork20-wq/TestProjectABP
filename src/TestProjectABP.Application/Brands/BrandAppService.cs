using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TestProjectABP.Brands
{
    public class BrandAppService : CrudAppService<Brand, BrandDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBrandDto>, IbrandAppService
    {

        public BrandAppService(IRepository<Brand, Guid> repository) : base(repository)
        {

        }
    }
}
