using Microsoft.AspNetCore.Mvc;
using SPV.Models;
using SPV.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext db;

        public OrderController(AppDbContext db)
        {
            this.db = db;
        }


        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<Order>? Get()
        {
            var orders = db.Orders.ToList();

            if (orders == null || orders.Count < 1) return null;

            return orders;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Order? Get(int id)
        {
            Order? order = db.Orders.FirstOrDefault(o => o.Id == id);

            if (order == null) return null;

            return order;
        }

        // POST api/<OrderController>
        [HttpPost]
        public Order? Post([FromBody] Order newOrder)
        {
            if(newOrder == null || newOrder.Id < 0) return null;

            var order = db.Orders.Add(newOrder);
            db.SaveChanges();

            return order.Entity;
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Order changeOrder)
        {
            if (id != changeOrder.Id) return false;

            Order? oldOrder = db.Orders.FirstOrDefault(x => x.Id == id);

            if(oldOrder == null) return false;

            oldOrder.RestaurantId = changeOrder.RestaurantId;
            oldOrder.UserId = changeOrder.UserId;
            oldOrder.OrderDate = changeOrder.OrderDate;
            oldOrder.DeliveryAddress = changeOrder.DeliveryAddress;
            oldOrder.TotalCost = changeOrder.TotalCost;
            oldOrder.OrderItems = changeOrder.OrderItems;
            db.SaveChanges();

            return true;
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public Order? Delete(int id)
        {
            if (id < 0) return null;

            Order? deletingOrder = db.Orders.FirstOrDefault(x => x.Id == id);

            if(deletingOrder == null) return null;

            var deleted = db.Orders.Remove(deletingOrder);
            db.SaveChanges();

            return deleted.Entity;
        }
    }
}
