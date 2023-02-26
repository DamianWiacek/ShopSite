using Microsoft.EntityFrameworkCore;
using ShopSite.Entities;
using ShopSite.Migrations;
using ShopSite.Models;

namespace ShopSite.Repositories
{
    public interface IOrderRepository
    {
        Task AddtoOrder(OrderDetails orderDetails);
        Task<List<OrderDetails>> GetAllOrderDetails(int id);
        Task<Order> GetOrder(int id);
        Task NewOrder(Order order);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopDbContext _dbContext;

        public OrderRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddtoOrder(OrderDetails orderDetails)
        {
             await _dbContext.OrderDetails.AddAsync(orderDetails);
            await _dbContext.SaveChangesAsync();
           
        }

        public async Task<List<OrderDetails>> GetAllOrderDetails(int id)
        {
            return await _dbContext.OrderDetails.Where(o => o.OrderId == id).ToListAsync();
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _dbContext.Orders.Include(o=>o.OrderDetails).ThenInclude(p=>p.Product).FirstOrDefaultAsync(o => o.Id == id);
              
        }

        public async Task NewOrder(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
