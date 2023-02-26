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

        [HttpPost]
        public async Task<ActionResult> AddProductsToOrder([FromBody] OrderDetailsDto orderDetailsDto)
        {
            await _orderService.AddProductsToOrder(orderDetailsDto);
            return Ok();
        }

    }
}
