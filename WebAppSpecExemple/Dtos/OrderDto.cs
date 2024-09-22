namespace WebAppSpecExemple.Dtos;

public class OrderDto
{
    public int Id { get; set; }
    public string Status { get; set; }
    public CustomerDto Customer { get; set; }
    public List<OrderDetailDto> OrderDetails { get; set; }

    private class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<Customer, CustomerDto>();
        }
    }
}
public class OrderDetailDto
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string Product { get; set; }
}
public class CustomerDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}
