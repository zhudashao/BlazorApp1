using System.Reflection;

namespace WebAppSpecExemple.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

    public ApplicationDbContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
