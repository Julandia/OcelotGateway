using Microsoft.AspNet.SignalR;
using System;

namespace SignalRChatService
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }

        public void JoinGroup(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
            string message = $"New group {groupName} joined chat";
            Console.WriteLine(message);
            Clients.All.Playback(message);
            Clients.Caller.Playback($"Welcome join the chat, {groupName}!");
        }
    }
}