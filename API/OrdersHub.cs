using Microsoft.AspNetCore.SignalR;

namespace API;

public class OrdersHub : Hub
{
    
    public async Task UpdateOrders()
    {
        await Clients.Group("Cocina").SendAsync("UpdateOrders");
    }

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }
    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }


    public async Task RefreshCocina()
    {
        await Clients.Group("Cocina").SendAsync("RefreshCocina");
    }
    
}