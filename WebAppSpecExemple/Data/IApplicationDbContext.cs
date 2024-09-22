namespace WebAppSpecExemple.Data;

public  interface IApplicationDbContext
{
    public DbSet<Order> Orders { get; }
    public DbSet<OrderDetail> OrderDetails { get; }
    public DbSet<Customer> Customers { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}