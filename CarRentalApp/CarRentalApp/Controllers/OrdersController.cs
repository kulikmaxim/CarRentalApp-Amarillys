using BLL.Contracts;
using BLL.Models;
using CarRentalApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarRentalApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET: api/Orders/4
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await orderService.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // GET: api/Orders?param1=value1&param2=value2
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery]OrderFilter filter)
        {
            var orders = await orderService
                .GetAsync(o => (!filter.RentalBeginDate.HasValue || o.RentalBeginDate == filter.RentalBeginDate)
                           && (!filter.RentalEndDate.HasValue || o.RentalEndDate == filter.RentalEndDate)
                           && (string.IsNullOrEmpty(filter.UserName) || string.Equals(o.User.FirstName, filter.UserName))
                           && (string.IsNullOrEmpty(filter.Mark) || string.Equals(o.Car.Mark, filter.Mark))
                           && (string.IsNullOrEmpty(filter.Model) || string.Equals(o.Car.Model, filter.Model)));

            return Ok(orders);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderInfo order)
        {
            if (order == null || order.Id != default(int))
            {
                return BadRequest();
            }

            var newOrder = await orderService.AddAsync(order);
            return CreatedAtAction("Get", "Orders", new { id = newOrder.Id }, newOrder);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderInfo order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            var updatedOrder = await orderService.EditAsync(order);
            if (updatedOrder == null)
            {
                return NotFound();
            }

            return Ok(updatedOrder);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedOrder = await orderService.DeleteAsync(id);
            if (deletedOrder == null)
            {
                return NotFound();
            }

            return Ok(deletedOrder);
        }
    }
}
