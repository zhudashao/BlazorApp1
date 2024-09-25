namespace BlazorApp4AvenantDemoTests;

using BlazorApp4AvenantDemo.Components.Pages;
using BlazorApp4AvenantDemo.Models;
using Bunit;
using Microsoft.AspNetCore.Components;
using Moq;
using Xunit;

public class OrderComponentTests : TestContext
{
    [Fact]
    public void AddOrder_ShouldInvoke_OnAddOrder()
    {
        // Arrange
        var addOrderCalled = false;
        var onAddOrderCallback = EventCallback.Factory.Create(this, () => addOrderCalled = true);

        var orders = new List<Order>();
        var cut = RenderComponent<OrderComponent>(parameters => parameters
            .Add(p => p.Orders, orders)
            .Add(p => p.OnAddOrder, onAddOrderCallback)
        );

        // Act
        cut.Find("button").Click();

        // Assert
        Assert.True(addOrderCalled);
    }

    [Fact]
    public void RemoveOrder_ShouldInvoke_OnRemoveOrder()
    {
        // Arrange
        var orderToRemove = new Order { Description = "Test Order" };
        var removeOrderCalled = false;
        var onRemoveOrderCallback = EventCallback.Factory.Create<Order>(this, order =>
        {
            if (order == orderToRemove)
            {
                removeOrderCalled = true;
            }
        });

        var orders = new List<Order> { orderToRemove };
        var cut = RenderComponent<OrderComponent>(parameters => parameters
            .Add(p => p.Orders, orders)
            .Add(p => p.OnRemoveOrder, onRemoveOrderCallback)
        );

        // Act
        cut.FindAll("button")[2].Click(); // The second button is for "Remove"

        // Assert
        Assert.True(removeOrderCalled);
    }

    [Fact]
    public void EditOrder_ShouldInvoke_OnEditOrder()
    {
        // Arrange
        var orderToEdit = new Order { Description = "Test Order" };
        var editOrderCalled = false;
        var onEditOrderCallback = EventCallback.Factory.Create<Order>(this, order =>
        {
            if (order == orderToEdit)
            {
                editOrderCalled = true;
            }
        });

        var orders = new List<Order> { orderToEdit };
        var cut = RenderComponent<OrderComponent>(parameters => parameters
            .Add(p => p.Orders, orders)
            .Add(p => p.OnEditOrder, onEditOrderCallback)
        );

        // Act
        cut.FindAll("button")[1].Click(); // The first button after description is "Edit"

        // Assert
        Assert.True(editOrderCalled);
    }
}
