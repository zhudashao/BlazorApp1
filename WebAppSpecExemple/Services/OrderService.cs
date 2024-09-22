namespace WebAppSpecExemple.Services;

public class OrderService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public OrderService(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<OrderDto>> GetOrdersByStatusWithDetailsAndCustomer(string status, decimal? minPrice, int? customerId)
    {
        var query = _dbContext.Orders.AsQueryable();

        // Appliquer le filtre par statut
        if (!string.IsNullOrEmpty(status))
        {
            var orderStatusSpec = new OrderByStatusSpecification(status);
            query = SpecificationEvaluator<Order>.GetQuery(query, orderStatusSpec);
        }

        // Appliquer le filtre par customerId
        if (customerId.HasValue)
        {
            var customerSpec = new OrdersByCustomerSpecification(customerId.Value);
            query = SpecificationEvaluator<Order>.GetQuery(query, customerSpec);
        }

        // Appliquer le filtre sur les détails de commande si minPrice est fourni
        if (minPrice.HasValue)
        {
            var orderDetailSpec = new OrderDetailByMinPriceSpecification(minPrice.Value);
            query = query.Where(o => o.OrderDetails.Any(orderDetailSpec.Criteria.Compile()));
        }

        // Projeter vers DTOs via AutoMapper
        return await query
            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
