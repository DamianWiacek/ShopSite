using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopSite.Entities;
using ShopSite.Models;
using ShopSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Controllers
{
    [Route("api/OrdersController")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("/AddProductsToOrder")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> AddProductsToOrder([FromBody] OrderDetailsDto orderDetailsDto)
        {
            var id = await _orderService.AddProductsToOrder(orderDetailsDto);
            return Created($"/api/OrdersController/GetAllOrderDetails/{id}", null);
        }
        [HttpPost("/CreateNewOrder/{userId}")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> CreateOrder([FromRoute] int userId)
        {
            var id = await _orderService.CreateNewOrder(userId);
            return Created($"/api/OrdersController/GetOrder/{id}", null);
        }
        [HttpGet("GetAllOrderDetails/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<List<OrderDetailsDto>> GetAllOrderDetails([FromRoute]int id)
        {
            return await _orderService.GetAllOrderDetails(id);
        }
        [HttpGet("GetOrder/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<OrderDto> GetOrder([FromRoute] int id)
        {
            return await _orderService.GetOrder(id);
        }
    }
}
