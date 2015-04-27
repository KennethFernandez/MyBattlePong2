using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace MyBattlePong.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Join(string name,string grupo,string usuario)
        {
           await Groups.Add(Context.ConnectionId, grupo);
           if (usuario == "1") { Clients.Group(grupo).addNewMessageToPage(name, ">"+name + " joined.", true); }
           else { Clients.Group(grupo).addNewMessageToPage(name, "< joined.", false); }

        }

        public void Send(string name, string message,string grupo,string usuario)
        {
            // Call the addNewMessageToPage method to update clients.
            if (usuario == "1") { Clients.Group(grupo).addNewMessageToPage(name, message, true); }
            else { Clients.Group(grupo).addNewMessageToPage(name, message, false); }
           

        }

        public Task Disconnect(string grupo)
        {
           return  Clients.Group(grupo).leave(Context.ConnectionId);
        }
    }
}