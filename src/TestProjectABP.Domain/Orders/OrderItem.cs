using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace TestProjectABP.Orders
{
    public class OrderItem : Entity<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Count { get; set; }

        public OrderItem() { }

        public OrderItem(Guid orderId, Guid productId, decimal unitPrice, int count)
        {
            OrderId = orderId;
            ProductId = productId;
            UnitPrice = unitPrice;
            Count = count;
        }

        public void UpdateCount(int newCount)
        {
            if (newCount <= 0)
            {
                throw new UserFriendlyException("الكمية يجب أن تكون أكبر من صفر");
            }
            Count = newCount;
        }
    }
}
