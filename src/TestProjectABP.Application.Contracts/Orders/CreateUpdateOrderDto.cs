using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectABP.Orders
{
    public class CreateUpdateOrderDto
    {
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}
