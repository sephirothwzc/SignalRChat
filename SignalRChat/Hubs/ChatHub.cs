using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace SignalRChat.Hubs
{
    /// <summary>
    /// You will use this class as a SignalR server hub that sends messages to all clients
    /// </summary>
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        public override Task OnConnected()
        {
            //Program.MainForm.WriteToConsole("Client connected: " + Context.ConnectionId);
            Clients.All.addNewMessageToPage("SYSTEM", Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Clients.All.addNewMessageToPage("SYSTEM", Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }
}