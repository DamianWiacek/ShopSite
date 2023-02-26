using Microsoft.EntityFrameworkCore;
using ShopSite.Entities;
using ShopSite.Models;

namespace ShopSite.Repositories
{
    public interface IOrderRepository
    {
        Task AddtoOrder(OrderDetails orderDetails);


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
    }
}
