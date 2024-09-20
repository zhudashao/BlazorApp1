namespace BlazorApp1.Models;


public class AggregateObject
{
    public int Id{ get; set; }
    public string Property1 { get; set; }
    public string Property2 { get; set; }
    public string Property3 { get; set; }
    public string Property4 { get; set; }
    public string Property5 { get; set; }

    public List<Order> Orders { get; set; } = new List<Order>();
    public List<Shipment> Shipments { get; set; } = new List<Shipment>();
}

public class Order
{
    public int Id { get; set; }
    public string Description { get; set; }
}

public class Shipment
{
    public int Id { get; set; }
    public string Address { get; set; }
}

public class AddShipmentDto
{
    public int AggregateId { get; set; }
    public Shipment Shipment { get; set; }
}

public class ModifyShipmentDto
{
    public int AggregateId { get; set; }
    public Shipment Shipment { get; set; }
}

public class DeleteShipmentDto
{
    public int AggregateId { get; set; }
    public int ShipmentId { get; set; }
}

public class AddOrderDto
{
    public int AggregateId { get; set; }
    public Order Order { get; set; }
}

public class ModifyOrderDto
{
    public int AggregateId { get; set; }
    public Order Order { get; set; }
}

public class DeleteOrderDto
{
    public int AggregateId { get; set; }
    public int OrderId { get; set; }
}

public record AggregateObjectDto(int Id,string Property1, string Property2, string Property3, string Property4, string Property5);
