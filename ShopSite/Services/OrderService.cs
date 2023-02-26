using AutoMapper;
using ShopSite.Entities;
using ShopSite.Models;
using ShopSite.Repositories;

namespace ShopSite.Services
{
    public interface IOrderService
    {

        Task AddProductsToOrder(OrderDetailsDto orderDetailsDto);
        
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        


        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        
        
        public async Task AddProductsToOrder(OrderDetailsDto orderDetailsDto)
        {
            var orderDetails =_mapper.Map<OrderDetails>(orderDetailsDto);
            await _repository.AddtoOrder(orderDetails);
        }
    }
}
