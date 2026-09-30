using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace TestProjectABP.Orders
{
    public class OrderItemDto : EntityDto<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Count { get; set; }
    }
}
