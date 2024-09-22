namespace WebAppSpecExemple.Entites;

public class Order
{
    public int Id { get; set; }
    public string Status { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}

public class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public decimal Price { get; set; }
    public string Product { get; set; }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
