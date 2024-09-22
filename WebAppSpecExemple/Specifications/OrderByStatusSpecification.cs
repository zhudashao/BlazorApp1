namespace WebAppSpecExemple.Specifications;

public class OrderByStatusSpecification : BaseSpecification<Order>
{
    public OrderByStatusSpecification(string status)
        : base(o => o.Status == status)
    {
    }
}
