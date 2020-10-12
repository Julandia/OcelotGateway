using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChatClient
{
    class ChatClient : IDisposable
    {
        private const string GroupName = "Susan";
        private string HubUrl;

        public ChatClient(string hubUrl)
        {
            HubUrl = hubUrl;
        }

        public void Dispose() { }

        public async Task Start()
        {
            using (var hubConnection = new HubConnection(HubUrl))
            {
                IHubProxy chatHubProxy = hubConnection.CreateHubProxy("ChatHub");
                chatHubProxy.On("Playback", message =>
                    Console.WriteLine($"Playback from ChatHub: {message}")
                ); ;
                await hubConnection.Start();

                Console.WriteLine($"Join ChatHub...");
                await chatHubProxy.Invoke("JoinGroup", "Susan");
            }
        }
    }
}
