using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProjectABP.Products;
using Volo.Abp.Domain.Entities.Auditing;

namespace TestProjectABP.Orders
{
    public class Order : FullAuditedAggregateRoot<Guid>
    {
        public string OrderNumber { get; set; }
        public OrderStatusEnum Status { get; private set; } = OrderStatusEnum.Pending;
        public decimal TotalPrice { get; private set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(string orderNumber, Guid? id = null) : base(id ?? Guid.NewGuid())
        {
            OrderNumber = orderNumber;
            Status = OrderStatusEnum.Pending;
        }

        public void CalculateTotalPrice()
        {
            TotalPrice = Items.Sum(x => x.UnitPrice * x.Count);
        }
        public void AddItem(Guid productId, decimal unitPrice, int count)
        {
            var existingItem = Items.FirstOrDefault(x => x.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.UpdateCount(existingItem.Count + count); ;
            }
            else
            {
                Items.Add(new OrderItem ( Id , productId, unitPrice, count ));
            }
            CalculateTotalPrice();
        }
        public void ChangeStatus(OrderStatusEnum status) 
        {
            Status = status;
        }
    }
}
