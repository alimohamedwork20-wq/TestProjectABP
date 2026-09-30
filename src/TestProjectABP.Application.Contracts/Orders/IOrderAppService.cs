using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace TestProjectABP.Orders
{
    public interface IOrderAppService : ICrudAppService<OrderDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateOrderDto>
    {
        Task<OrderDto> CancelOrderAsync(Guid id);
    }
}
