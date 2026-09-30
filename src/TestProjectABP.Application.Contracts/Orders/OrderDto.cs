using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
namespace TestProjectABP.Orders
{
    public class OrderDto : FullAuditedEntityDto<Guid>
    {
        public string OrderNumber { get; set; }
        public OrderStatusEnum Status { get; set; } = OrderStatusEnum.Pending;
        public decimal TotalPrice { get;  set; }
        public List<CreateOrderItemDto> Items { get; set; } = new List<CreateOrderItemDto>();
    }
}
