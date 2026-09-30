using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TestProjectABP.Suppliers
{
    public interface ISupplierAppService : ICrudAppService<SupplierDto, Guid,PagedAndSortedResultRequestDto, CreateUpdateSupplierDto>
    {
    }
}
