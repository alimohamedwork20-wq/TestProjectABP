using System;

using System.Threading.Tasks;
using TestProjectABP.Products;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TestProjectABP.Orders
{
    public class OrderAppService : CrudAppService<Order,OrderDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateOrderDto>, IOrderAppService
    {
        private readonly IRepository<Product, Guid> _productRepository;
        public OrderAppService(IRepository<Order, Guid> repository, IRepository<Product, Guid> productRepository) : base(repository)
        {
            _productRepository = productRepository;
        }

        public override async Task<OrderDto> CreateAsync(CreateUpdateOrderDto input)
        {
            var orderNumber = $"ORD-{DateTime.UtcNow:yyyyMMddHHmmss}";
            var order = new Order(orderNumber);

            foreach (var item in input.Items)
            {
                var product = await _productRepository.GetAsync(item.ProductId);
                order.AddItem(product.Id, product.Price, item.Count);
            }
            await Repository.InsertAsync(order, autoSave: true);
            return ObjectMapper.Map<Order, OrderDto>(order);
        }
        public async Task<OrderDto> CancelOrderAsync(Guid id)
        {
            var order = await Repository.FirstOrDefaultAsync(x => x.Id == id);
            order.ChangeStatus(OrderStatusEnum.Cancelled);
            await Repository.UpdateAsync(order);
            return ObjectMapper.Map<Order, OrderDto>(order);
        }
    }
}
