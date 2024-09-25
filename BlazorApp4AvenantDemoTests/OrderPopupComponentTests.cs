using BlazorApp4AvenantDemo.Components.Pages;
using BlazorApp4AvenantDemo.Models;
using Bunit;
using Microsoft.AspNetCore.Components;

namespace BlazorApp4AvenantDemoTests;
public class OrderPopupComponentTests : TestContext
{
    [Fact]
    public void Shows_Add_Order_When_OrderToEdit_Is_Null()
    {
        // Arrange
        var cut = RenderComponent<OrderPopup>(parameters => parameters
            .Add(p => p.OrderToEdit, null)
        );

        // Act
        var header = cut.Find("h3").TextContent;

        // Assert
        Assert.Equal("Add Order", header);
    }

    [Fact]
    public void Shows_Edit_Order_When_OrderToEdit_Is_Not_Null()
    {
        // Arrange
        var orderToEdit = new Order { Id = 1, Description = "Test Order" };
        var cut = RenderComponent<OrderPopup>(parameters => parameters
            .Add(p => p.OrderToEdit, orderToEdit)
        );

        // Act
        var header = cut.Find("h3").TextContent;
        var input = cut.Find("input").GetAttribute("value");

        // Assert
        Assert.Equal("Edit Order", header);
        Assert.Equal("Test Order", input);
    }

    [Fact]
    public void Save_Should_Invoke_OnOrderAdded_When_Creating_New_Order()
    {
        // Arrange
        var orderAddedCalled = false;
        var onOrderAddedCallback = EventCallback.Factory.Create<Order>(this, (Order order) =>
        {
            orderAddedCalled = true;
        });

        var cut = RenderComponent<OrderPopup>(parameters => parameters
            .Add(p => p.OrderToEdit, null) // New order
            .Add(p => p.OnOrderAdded, onOrderAddedCallback)
        );

        // Act
        cut.Find("button").Click(); // Click "Save"

        // Assert
        Assert.True(orderAddedCalled);
    }

    [Fact]
    public void Save_Should_Invoke_OnOrderEdited_When_Editing_Order()
    {
        // Arrange
        var orderToEdit = new Order { Id = 1, Description = "Existing Order" };
        var orderEditedCalled = false;
        var onOrderEditedCallback = EventCallback.Factory.Create<Order>(this, (Order order) =>
        {
            orderEditedCalled = true;
        });

        var cut = RenderComponent<OrderPopup>(parameters => parameters
            .Add(p => p.OrderToEdit, orderToEdit)
            .Add(p => p.OnOrderEdited, onOrderEditedCallback)
        );

        // Act
        cut.Find("button").Click(); // Click "Save"

        // Assert
        Assert.True(orderEditedCalled);
    }

    [Fact]
    public void Cancel_Should_Invoke_OnClose()
    {
        // Arrange
        var closeCalled = false;
        var onCloseCallback = EventCallback.Factory.Create(this, () => closeCalled = true);

        var cut = RenderComponent<OrderPopup>(parameters => parameters
            .Add(p => p.OnClose, onCloseCallback)
        );

        // Act
        cut.FindAll("button")[1].Click(); // Click "Cancel"

        // Assert
        Assert.True(closeCalled);
    }
}
