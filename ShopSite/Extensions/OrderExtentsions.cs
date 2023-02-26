using ShopSite.Entities;

namespace ShopSite.Extensions
{
    public static class OrderExtentsions
    {
        public static double GetTotalPrice(this Order order)
        {
            return order.OrderDetails.Sum(d => d.Product.Price) * order.OrderDetails.Sum(x => x.Quantity);
            
        }
    }
}
