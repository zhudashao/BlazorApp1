namespace WebAppSpecExemple.Specifications;

public class OrderDetailByMinPriceSpecification : BaseSpecification<OrderDetail>
{
    public OrderDetailByMinPriceSpecification(decimal minPrice)
        : base(od => od.Price >= minPrice)
    {
    }
}
