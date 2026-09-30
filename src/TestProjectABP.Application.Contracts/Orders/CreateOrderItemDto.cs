using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectABP.Orders
{
    public class CreateOrderItemDto
    {
        public Guid ProductId { get; set; }
        public int Count { get; set; } = 1;
    }
}
