using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopyWhere.API.Data.Entities;
using ShopyWhere.API.Data.Repositories;
using ShopyWhere.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopyWhere.API.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderController(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post(OrderModel model)
        {
            try
            {
                var order = new Order();
                order.Adress = model.Adress;

                var result = await _orderRepository.Add(order);
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
