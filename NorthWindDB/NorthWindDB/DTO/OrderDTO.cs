namespace NorthWindDB.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }

        public string CustomerName { get; set; }

        public string ProductName { get; set; }

        public decimal? Price { get; set; }

        public int? quantity { get; set; }

        public OrderDTO(int orderId, DateTime? orderDate, string customerName, string productName, decimal? price, int? quantity)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            CustomerName = customerName;
            ProductName = productName;
            Price = price;
            this.quantity = quantity;
        }
    }
}
