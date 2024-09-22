namespace WebAppSpecExemple.Specifications;

public class OrdersByCustomerSpecification : BaseSpecification<Order>
{
    public OrdersByCustomerSpecification(int customerId)
        : base(o => o.CustomerId == customerId)
    {
    }
}
