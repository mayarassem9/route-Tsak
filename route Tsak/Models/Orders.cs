using route_Tsak.Enum;

namespace route_Tsak.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Statusenum statusenum { get; set; }
        public paymentenum paymentenum { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
        public Customer Customer { get; set; }






    }
}
