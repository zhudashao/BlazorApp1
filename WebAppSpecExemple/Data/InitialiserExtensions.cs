namespace WebAppSpecExemple.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedCustomersAsync();
            await TrySeedOrdersAsync();
            await TrySeedOrderDetailsAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedCustomersAsync()
    {
        // Si la table Customers est vide, ajouter des données
        if (!_context.Customers.Any())
        {
            _context.Customers.Add(new Customer
            {
                Id = 1,
                Name = "John Doe"
            });

            _context.Customers.Add(new Customer
            {
                Id = 2,
                Name = "Jane Smith"
            });

            await _context.SaveChangesAsync();
        }
    }

    public async Task TrySeedOrdersAsync()
    {
        // Si la table Orders est vide, ajouter des données
        if (!_context.Orders.Any())
        {
            _context.Orders.Add(new Order
            {
                Id = 1,
                Status = "Processing",
                CustomerId = 1
            });

            _context.Orders.Add(new Order
            {
                Id = 2,
                Status = "Shipped",
                CustomerId = 2
            });

            await _context.SaveChangesAsync();
        }
    }

    public async Task TrySeedOrderDetailsAsync()
    {
        // Si la table OrderDetails est vide, ajouter des données
        if (!_context.OrderDetails.Any())
        {
            _context.OrderDetails.Add(new OrderDetail
            {
                Id = 1,
                OrderId = 1,
                Price = 19.99m,
                Product = "Laptop"
            });

            _context.OrderDetails.Add(new OrderDetail
            {
                Id = 2,
                OrderId = 1,
                Price = 49.99m,
                Product = "Monitor"
            });

            _context.OrderDetails.Add(new OrderDetail
            {
                Id = 3,
                OrderId = 2,
                Price = 10.00m,
                Product = "Mouse"
            });

            await _context.SaveChangesAsync();
        }
    }
}
