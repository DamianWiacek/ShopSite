using AutoMapper;
using ShopSite.Entities;
using ShopSite.Extensions;
using ShopSite.Models;
using ShopSite.Repositories;

namespace ShopSite.Services
{
    public interface IOrderService
    {

        Task<int> AddProductsToOrder(OrderDetailsDto orderDetailsDto);
        Task<int> CreateNewOrder(int userId);
        Task<List<OrderDetailsDto>> GetAllOrderDetails(int id);
        Task<OrderDto> GetOrder(int id);
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
        public async Task<int> CreateNewOrder(int userId)
        {
            var order = new Order()
            {
                UserId = userId
            };
            await _repository.NewOrder(order);
            return order.Id;
        }
        
        public async Task<int> AddProductsToOrder(OrderDetailsDto orderDetailsDto)
        {
            var orderDetails =_mapper.Map<OrderDetails>(orderDetailsDto);
            await _repository.AddtoOrder(orderDetails);
            return orderDetails.Id;
        }

        public async Task<List<OrderDetailsDto>> GetAllOrderDetails(int id)
        {
            var orderDetails =  await _repository.GetAllOrderDetails(id);
            var orderDetailsDto = _mapper.Map<List<OrderDetailsDto>>(orderDetails);
            return orderDetailsDto;
        }

        public async Task<OrderDto> GetOrder(int id)
        {
            var order = await _repository.GetOrder(id);
            var orderDto = _mapper.Map<OrderDto>(order);
            orderDto.TotalPrice = order.GetTotalPrice();
            return orderDto;
        }
    }
}
