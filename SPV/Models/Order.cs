namespace SPV.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string? RestaurantId { get; set; }
        public string? UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? DeliveryAddress { get; set; }
        public decimal TotalCost { get; set; }
        public string? OrderItems { get; set; }

        public Order() { }

        public Order(string restaurantId, string UserId, string address, decimal totalCost, string orderItems)
        {
            this.RestaurantId = restaurantId;
            this.UserId = UserId;
            OrderDate= DateTime.Now;
            this.DeliveryAddress = address;
            this.TotalCost = totalCost;
            this.OrderItems = orderItems;
        }

        public Order(DateTime orderDate, string restaurantId, string UserId, string address, decimal totalCost, string orderItems)
        {
            this.OrderDate = orderDate;
            this.RestaurantId = restaurantId;
            this.UserId = UserId;
            OrderDate = DateTime.Now;
            this.DeliveryAddress = address;
            this.TotalCost = totalCost;
            this.OrderItems = orderItems;
        }
    }
}
