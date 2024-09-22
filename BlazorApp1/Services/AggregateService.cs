using BlazorApp4AvenantDemo.Models;

namespace BlazorApp4AvenantDemo.Services;

public class AggregateService
{
    // Simulate fetching the AggregateObject by aggregateId
    public Task<AggregateObject> GetAggregateObjectAsync(int aggregateId)
    {
        // Simulate a delay to mimic a network call
        return Task.Delay(1000).ContinueWith(task =>
        {
            // Return a mocked AggregateObject based on aggregateId
            return new AggregateObject
            {
                Id = aggregateId,
                Property1 = "Property value 1",
                Property2 = "Property value 2",
                Property3 = "Property value 3",
                Property4 = "Property value 4",
                Property5 = "Property value 5",
                Orders = new List<Order>
                {
                    new Order { Id = 1, Description = "Order 1" },
                    new Order { Id = 2, Description = "Order 2" }
                },
                Shipments = new List<Shipment>
                {
                    new Shipment { Id = 1, Address = "Shipment Address 1" },
                    new Shipment { Id = 2, Address = "Shipment Address 2" }
                }
            };
        });
    }

    // Simulate adding a shipment
    public Task AddShipmentAsync(AddShipmentDto dto)
    {
        Console.WriteLine($"Adding Shipment to AggregateId {dto.AggregateId}");
        Console.WriteLine($"Shipment Address: {dto.Shipment.Address}");

        // Simulate sending the data to the server
        return Task.Delay(500); // Simulate a network call
    }

    // Simulate modifying a shipment
    public Task ModifyShipmentAsync(ModifyShipmentDto dto)
    {
        Console.WriteLine($"Modifying Shipment in AggregateId {dto.AggregateId}");
        Console.WriteLine($"Shipment Id: {dto.Shipment.Id}, New Address: {dto.Shipment.Address}");

        // Simulate sending the data to the server
        return Task.Delay(500); // Simulate a network call
    }

    // Simulate deleting a shipment
    public Task DeleteShipmentAsync(DeleteShipmentDto dto)
    {
        Console.WriteLine($"Deleting Shipment from AggregateId {dto.AggregateId}");
        Console.WriteLine($"Shipment Id: {dto.ShipmentId}");

        // Simulate sending the data to the server
        return Task.Delay(500); // Simulate a network call
    }

    // Simulate adding an order
    public Task AddOrderAsync(AddOrderDto dto)
    {
        Console.WriteLine($"Adding Order to AggregateId {dto.AggregateId}");
        Console.WriteLine($"Order Description: {dto.Order.Description}");

        // Simulate sending the data to the server
        return Task.Delay(500); // Simulate a network call
    }

    // Simulate modifying an order
    public Task ModifyOrderAsync(ModifyOrderDto dto)
    {
        Console.WriteLine($"Modifying Order in AggregateId {dto.AggregateId}");
        Console.WriteLine($"Order Id: {dto.Order.Id}, New Description: {dto.Order.Description}");

        // Simulate sending the data to the server
        return Task.Delay(500); // Simulate a network call
    }

    // Simulate deleting an order
    public Task DeleteOrderAsync(DeleteOrderDto dto)
    {
        Console.WriteLine($"Deleting Order from AggregateId {dto.AggregateId}");
        Console.WriteLine($"Order Id: {dto.OrderId}");

        // Simulate sending the data to the server
        return Task.Delay(500); // Simulate a network call
    }

    public Task UpdateAggregateObjectAsync(AggregateObjectDto dto)
    {
        Console.WriteLine($"Aggregate Id {dto.Id}");
        Console.WriteLine($"Aggregate property1 {dto.Property1}");
        Console.WriteLine($"Aggregate property2 {dto.Property2}");
        Console.WriteLine($"Aggregate property3 {dto.Property3}");
        Console.WriteLine($"Aggregate property4 {dto.Property4}");
        Console.WriteLine($"Aggregate property5 {dto.Property5}");

        // Simulate sending the data to the server
        return Task.Delay(500); // Simulate a network call
    }
    
}

