using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:5000/";
            using (var client = new ChatClient(baseAddress))
            {
                client.Start().Wait();
                Console.ReadLine();
            }
        }
    }
}
